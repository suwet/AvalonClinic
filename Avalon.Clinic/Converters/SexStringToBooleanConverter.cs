using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;

namespace Avalon.Clinic.Converters {
    public class SexStringToBooleanConverter : IValueConverter {
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
           string? v = value as string;
            bool result;
            if (string.IsNullOrEmpty(v))
                result = false;

            if(v != null && v.Equals(parameter as string)) {
                result = true;
            }
            else {
                result = false;
            }
            return result;
        }

        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            bool? v = value as bool?;
            if(v.HasValue && v==true ) {
                return "man";
            }else {
                return "woman"; 
            }
        }
    }
}
