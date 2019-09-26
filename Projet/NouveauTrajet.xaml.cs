using Métier2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class NouveauTrajet : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public NouveauTrajet()
        {
            this.InitializeComponent();
            DataContext = Manager;
            ComboBoxMeteo.ItemsSource = Enum.GetValues(typeof(Meteo));
            ComboBoxTrafic.ItemsSource = Enum.GetValues(typeof(Trafic));
        }

        private void Enregistrer(object sender, RoutedEventArgs e)
        {
                Manager.AjouterTrajet(new Trajet(new DateTime(BoxDate.Date.Year, BoxDate.Date.Month, BoxDate.Date.Day), BoxDepart.Text, BoxArrivee.Text, Duree.Time, Convert.ToInt32(BoxKm.Text), Manager.SelectedVoiture, (Meteo)ComboBoxMeteo.SelectedItem, (Trafic)ComboBoxTrafic.SelectedItem, BoxRemarques.Text));
                Frame.Navigate(typeof(Carnet));
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Carnet));
        }

        private void AddFavorite(object sender, RoutedEventArgs e)
        {
            Manager.AjouterFavori(new Trajet(new DateTime(BoxDate.Date.Year, BoxDate.Date.Month, BoxDate.Date.Day), BoxDepart.Text, BoxArrivee.Text, Duree.Time, Convert.ToInt32(BoxKm.Text), Manager.SelectedVoiture, Meteo.Soleil, Trafic.Dense, BoxRemarques.Text));
        }
    }
}
