﻿using OpenSAE.Core;
using OpenSAE.Core.SAML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSAE.Models
{
    public class SymbolArtModel : SymbolArtItemModel
    {
        private string? _name;
        private bool _visible;
        private string? _author;
        private int _height;
        private int _width;
        private SymbolArtSoundEffect _soundEffect;
        private SymbolArtFileFormat _fileFormat;

        public SymbolArtModel(string filename)
        {
            var sa = SymbolArt.LoadFromFile(filename);
            _name = sa.Name;
            _visible = sa.Visible;
            _height = sa.Height;
            _width = sa.Width;
            _soundEffect = sa.Sound;
            _fileFormat = sa.FileFormat;

            FileName = filename;

            foreach (var item in sa.Children)
            {
                if (item is ISymbolArtGroup subGroup)
                {
                    Children.Add(new SymbolArtGroupModel(subGroup, this));
                }
                else if (item is SymbolArtLayer layer)
                {
                    Children.Add(new SymbolArtLayerModel(layer, this));
                }
                else
                {
                    throw new Exception($"Item of unknown type {item.GetType().Name} found in symbol art");
                }
            }
        }

        public SymbolArtModel()
        {
            _name = "NewSymbolArt";
            _author = "0";
            _width = 192;
            _height = 96;
            _soundEffect = SymbolArtSoundEffect.None;
            _visible = true;
        }

        /// <summary>
        /// If the symbol art was loaded from a file, contains the file it was loaded from
        /// </summary>
        public string? FileName { get; private set; }

        public override string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string? Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public override bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        public override bool IsVisible => Visible;

        public SymbolArtSize Size
        {
            get
            {
                if (_height == 96 && _width == 192)
                    return SymbolArtSize.Standard;

                if (_width == 32 && _height == 32)
                    return SymbolArtSize.AllianceLogo;

                return SymbolArtSize.NonStandard;
            }
            set
            {
                switch (value)
                {
                    case SymbolArtSize.AllianceLogo:
                        _height = 32;
                        _width = 32;
                        break;

                    case SymbolArtSize.Standard:
                        _width = 192;
                        _height = 96;
                        break;
                }
            }
        }

        public int Width => _width;

        public int Height => _height;

        public SymbolArtSoundEffect SoundEffect
        {
            get => _soundEffect;
            set => SetProperty(ref _soundEffect, value);
        }

        public List<SymbolArtSizeOptionModel> SizeOptions => new()
        {
            new SymbolArtSizeOptionModel(SymbolArtSize.Standard, "Standard"),
            new SymbolArtSizeOptionModel(SymbolArtSize.AllianceLogo, "Alliance logo")
        };

        public List<SymbolArtSoundEffectOptionModel> SoundEffectOptions => new()
        {
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.None, "None"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Default, "Default"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Joy, "Joy"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Anger, "Anger"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Sorrow, "Sorrow"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Unease, "Unease"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Surprise, "Surprise"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Doubt, "Doubt"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Help, "Help"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Whistle, "Whistle"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.Embarrassed, "Embarrassed"),
            new SymbolArtSoundEffectOptionModel(SymbolArtSoundEffect.NailedIt, "Nailed it!")
        };

        public List<SymbolArtModel> RootItems => new() { this };

        public void Save()
        {
            if (string.IsNullOrEmpty(FileName))
            {
                throw new InvalidOperationException("Cannot save in-place as Symbol Art was not created from a file");
            }

            SaveAs(FileName, _fileFormat == SymbolArtFileFormat.None ? SymbolArtFileFormat.SAML : _fileFormat);
        }

        public void SaveAs(string filename, SymbolArtFileFormat format)
        {
            using var fs = File.Create(filename);

            var symbolArt = (SymbolArt)ToSymbolArtItem();

            symbolArt.Save(fs, format);
        }

        public override SymbolArtItemModel Duplicate(SymbolArtItemModel parent)
        {
            throw new InvalidOperationException("Cannot duplicate symbol art root");
        }

        public override SymbolArtItem ToSymbolArtItem()
        {
            return new SymbolArt()
            {
                Author = _author,
                FileFormat = _fileFormat,
                Children = Children.Select(x => x.ToSymbolArtItem()).ToList(),
                Name = _name,
                Height = _height,
                Sound = _soundEffect,
                Version = 4,
                Visible = _visible,
                Width = _width
            };
        }
    }
}
