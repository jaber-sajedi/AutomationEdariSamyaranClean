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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var type = value.GetType();
            if (!type.IsEnum) return value.ToString();

            var member = type.GetMember(value.ToString()).FirstOrDefault();
            if (member != null)
            {
                var displayAttr = member.GetCustomAttribute<DisplayAttribute>();
                if (displayAttr != null) return displayAttr.Name;
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            foreach (var field in targetType.GetFields())
            {
                var displayAttr = field.GetCustomAttribute<DisplayAttribute>();
                if (displayAttr != null && displayAttr.Name == value.ToString())
                    return Enum.Parse(targetType, field.Name);
            }

            return Enum.Parse(targetType, value.ToString());
        }
    }
}
