using Métier2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Projet
{
    class Nom2UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string nom = value as string;
            if (string.IsNullOrWhiteSpace(nom)) return null;

            string assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
            string imageFileName = $"Assets/{nom.ToLower()}.jpg";
            Uri test = new Uri($"ms-appx://{assemblyName}/{imageFileName}");
            return test;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
