using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data.Converters;
using Avalon.Clinic.ViewModels;

namespace Avalon.Clinic.Converters {
    public class IntegerToStringConverter : IValueConverter {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            int result = value == null ? 0 : (int)value;
            return result.ToString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {

            return 10;
            
        }
    }
}
