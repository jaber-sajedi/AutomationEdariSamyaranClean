using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AutomationEdariSamyaran.WPF.Converter
{
    public class EnumDisplayNameConverter : IValueConverter
    {
        private static readonly Dictionary<Enum, string> _cache = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Enum enumValue)
                return value?.ToString();

            if (_cache.TryGetValue(enumValue, out var name))
                return name;

            var member = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            var displayName = member?
                .GetCustomAttribute<DisplayAttribute>()?
                .Name ?? enumValue.ToString();

            _cache[enumValue] = displayName;
            return displayName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Binding.DoNothing;
    }

}
