using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;

namespace Avalon.Clinic.Converters {
    // OK Work fine..
    public class IsActiveStringToBoolConvert : IValueConverter {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            string? result = (string?)value;
            if (result!=null && result.ToUpper() == "Y")
                return true;
            else
                return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            bool? ischeck = (bool?)value;
            if(ischeck.HasValue && ischeck.Value)
            {
                return "Y";
            }
            else 
            {
                return "N";
            }
        }
    }
}
