using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.ViewModel
{
    using System.Windows.Data;

    class TimeNumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = value;
            if (value is decimal)
            {
                result = ((decimal)value).ToString("00.00");
            }
            else if (value is int)
            {
                string param = (parameter == null)
                    ? "d1"
                    : parameter.ToString();
                result = ((int)value).ToString(param);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}