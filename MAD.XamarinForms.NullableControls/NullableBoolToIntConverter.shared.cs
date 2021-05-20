using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MAD.XamarinForms.NullableControls
{
    internal class NullableBoolToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolVal = value as bool?;

            if (boolVal is null)
            {
                return -1;
            }
            else if(boolVal == false)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
