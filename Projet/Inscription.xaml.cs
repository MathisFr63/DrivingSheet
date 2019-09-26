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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Inscription : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        string id, mdp, mdp2;
        bool ecole;

        public Inscription()
        {
            this.InitializeComponent();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Sinscrire(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mdp) || mdp.Length < 3) await AfficheMdpCourt();
            else if (!mdp.Equals(mdp2)) await AfficheErreur();
            else if (!await Manager.Inscription(id, mdp, ecole)) await AfficheCompteExistant();
            else this.Frame.Navigate(typeof(HomePage));
        }

        private async Task AfficheMdpCourt()
        {
            var dialog = new Windows.UI.Popups.MessageDialog($"Problème lors de l'inscription !{Environment.NewLine}Le mot de passe doit au moins contenir 3 caractères.", "Erreur");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continuer") { Id = 0 });

            dialog.DefaultCommandIndex = 0;

            var result = await dialog.ShowAsync();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            ecole = !ecole;
        }

        private async Task AfficheErreur()
        {
            var dialog = new Windows.UI.Popups.MessageDialog($"Problème lors de l'inscription !{Environment.NewLine}La confirmation du mot de passe n'est pas correcte.", "Erreur");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continuer") { Id = 0 });

            dialog.DefaultCommandIndex = 0;

            var result = await dialog.ShowAsync();
        }

        private async Task AfficheCompteExistant()
        {
            var dialog = new Windows.UI.Popups.MessageDialog($"Problème lors de l'inscription !{Environment.NewLine}Cette adresse e-mail est déjà utilisée. ", "Erreur");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continuer") { Id = 0 });

            dialog.DefaultCommandIndex = 0;

            var result = await dialog.ShowAsync();
        }
    }
}
