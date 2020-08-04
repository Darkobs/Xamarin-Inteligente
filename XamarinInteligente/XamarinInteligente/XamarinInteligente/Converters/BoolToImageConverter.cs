using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinInteligente.Converters
{
    class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool inputValue = (bool)value;
            //return inputValue
            //    ? ImageSource.FromFile("correct.png")
            //    : ImageSource.FromFile("failed.png");

            if(value is bool inputValue)
            {
                return inputValue ? ImageSource.FromFile("correct.png") : ImageSource.FromFile("failed.png");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
