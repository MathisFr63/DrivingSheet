

using Métier2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Projet
{
    class CompteCourantTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DateTemplateCompteCourant { get; set; }

        public DataTemplate DateTemplateCompteEcole { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if(item != null && (item as Manager).CompteCourant.GetType() == typeof(CompteClient))
            {
                return DateTemplateCompteCourant;
            }
            return DateTemplateCompteEcole;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
        public CompteCourantTemplateSelector()
        {

        }
    }
}
