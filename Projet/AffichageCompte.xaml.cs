using Métier2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AffichageCompte : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        public AffichageCompte()
        {
            this.InitializeComponent();
            DataContext = Manager;
        }

        private async void SupprimerProfil(object sender, RoutedEventArgs e)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Voulez-vous vraiment supprimer ce profil ?", "Vérification");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Supprimer") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Annuler") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            //var btn = sender as Button;
            //btn.Content = $"Result: {result.Label} ({result.Id})";

            if (result.Id.Equals(0))
                Manager.SupprimerProfil();
        }

        private async void SupprimerVoiture(object sender, RoutedEventArgs e)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Voulez-vous vraiment supprimer cette voiture ?", "Vérification");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Supprimer") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Annuler") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            //var btn = sender as Button;
            //btn.Content = $"Result: {result.Label} ({result.Id})";
            if (result.Id.Equals(0))
                Manager.SupprimerVoiture();
        }
        
        private async void SupprimerFavori(object sender, RoutedEventArgs e)
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Voulez-vous vraiment supprimer ce trajet favori ?", "Vérification");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Supprimer") { Id = 0 });
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Annuler") { Id = 1 });

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();

            //var btn = sender as Button;
            //btn.Content = $"Result: {result.Label} ({result.Id})";

            if (result.Id.Equals(0))
                Manager.SupprimerFavori();
        }

        public void AjouterProfil(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewProfil));
        }

        public void AjouterVoiture(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewVoiture));
        }

        public void AjouterFavori(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NouveauTrajet));
        }

        private void SupprimerFormateur(object sender, RoutedEventArgs e)
        {
            Manager.SupprimerMoniteur();
        }

        private void AjouterFormateur(object sender, RoutedEventArgs e)
        {
            Manager.SelectedIndexFormateur = -1;
            this.Frame.Navigate(typeof(ModifierFormateur));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Sauvegarde();
        }
    }
}
