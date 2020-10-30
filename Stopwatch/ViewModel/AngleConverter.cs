using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.ViewModel
{
    using System.Windows.Data;
    class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            double result = 0;
            double parsedValue;
            if ((value != null)
                && double.TryParse(value.ToString(), out parsedValue)
                && (parameter != null))
            {
                int angle = 0;
                switch (parameter.ToString())
                {
                    case "Hours":
                        angle = 30;
                        break;
                    case "Minutes":
                    case "Seconds":
                        angle = 6;
                        break;
                }
                result = parsedValue * angle;
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}