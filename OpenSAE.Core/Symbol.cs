﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace OpenSAE.Core
{
    public class Symbol
    {
        public Symbol(int id, string name, SymbolGroup group)
            : this(id, name, name, group)
        {
        }

        public Symbol(int id, string name, string description, SymbolGroup group)
        {
            Id = id;
            Name = name;
            Description = description;
            Group = group;

            Image = new BitmapImage();
            Image.BeginInit();
            Image.CacheOption = BitmapCacheOption.OnLoad;
            Image.UriSource = new Uri(Uri);
            Image.EndInit();
        }

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public string Uri => $"pack://application:,,,/OpenSAE.Core;component/assets/{Id}.png";

        public BitmapImage Image { get; }

        public SymbolGroup Group { get; }
    }
}