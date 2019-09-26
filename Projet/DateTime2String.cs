using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Projet
{
    class DateTime2String : IValueConverter
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
                return "";
            }

            string param = parameter as string;

            string dateTimeString;
            if (date.Equals(new DateTime()) || date.Equals(new DateTime(1917,1,1)))
                dateTimeString = "Inconnue";

            else
            {
                if (param == "d")
                    dateTimeString = date.ToString("d");
                else
                    dateTimeString = date.ToString("dd MMMM yyyy");
            }
            return dateTimeString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
