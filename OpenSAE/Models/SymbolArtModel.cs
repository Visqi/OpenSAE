﻿using OpenSAE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSAE.Models
{
    public class SymbolArtModel : SymbolArtItemModel
    {
        private readonly SymbolArt _sa;
        

        public SymbolArtModel(SymbolArt sa)
        {
            _sa = sa;

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
            _sa = SymbolArt.CreateBlank("NewSymbolArt");
        }

        public override string? Name
        {
            get => _sa.Name;
            set
            {
                _sa.Name = value;
                OnPropertyChanged();
            }
        }

        public override bool Visible
        {
            get => _sa.Visible;
            set
            {
                _sa.Visible = value;
                OnPropertyChanged();
            }
        }

        public override bool IsVisible => Visible;

        public SymbolArtSize Size
        {
            get
            {
                if (_sa.Height == 96 && _sa.Width == 192)
                    return SymbolArtSize.Standard;

                if (_sa.Width == 32 && _sa.Height == 32)
                    return SymbolArtSize.AllianceLogo;

                return SymbolArtSize.NonStandard;
            }
            set
            {
                switch (value)
                {
                    case SymbolArtSize.AllianceLogo:
                        _sa.Height = 32;
                        _sa.Width = 32;
                        break;

                    case SymbolArtSize.Standard:
                        _sa.Width = 192;
                        _sa.Height = 96;
                        break;
                }
            }
        }

        public SymbolArtSoundEffect SoundEffect
        {
            get => _sa.Sound;
            set
            {
                _sa.Sound = value;
                OnPropertyChanged();
            }
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
    }
}