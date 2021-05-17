using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;
using System.Globalization;

namespace KURS.Services
{
    public class ByteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromStream(() => new MemoryStream(value as byte[]));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
