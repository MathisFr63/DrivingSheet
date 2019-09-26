using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Projet
{
    class DateTime2DateTimeOffset : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date;
            try
            {
                date = (DateTime)value;
            }
            catch (InvalidCastException e)
            {
                return new DateTimeOffset();
            }

            if (date.Year < 1917) return new DateTimeOffset(1917, date.Month, date.Day,0,0,0,new TimeSpan());

            return new DateTimeOffset(date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset date = (DateTimeOffset)value;
            return new DateTime(date.Year, date.Month, date.Day);
        }
    }
}
