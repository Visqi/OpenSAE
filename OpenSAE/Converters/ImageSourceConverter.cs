﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OpenSAE.Converters
{
    internal class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] imageData)
            {
                BitmapImage biImg = new();
                MemoryStream ms = new(imageData);

                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();

                return biImg;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static void AssertImageIsReadable(byte[] imageData)
        {
            BitmapImage biImg = new();
            using MemoryStream ms = new(imageData);

            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
        }
    }
}
