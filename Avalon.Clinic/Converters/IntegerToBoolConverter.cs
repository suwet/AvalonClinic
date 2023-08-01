using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;


namespace Avalon.Clinic.Converters 
{
    public class IntegerToBoolConverter: IValueConverter {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            int? result = (int?)value;
            if (result.HasValue && result.Value == 1)
                return true;
            else
                return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            bool? ischeck = (bool?)value;
            if(ischeck.HasValue && ischeck.Value)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }
    }
}

