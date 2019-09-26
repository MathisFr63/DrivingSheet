using Métier2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        string id;
        string mdp;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Inscription));
        }

        private async void Connexion(object sender, RoutedEventArgs e)
        {
            if (Manager.Connexion(id, mdp).Result)
            {
                this.Frame.Navigate(typeof(HomePage));
                return;
            }

            var dialog = new Windows.UI.Popups.MessageDialog($"Problème lors de la connection !{Environment.NewLine} Veuillez vérifier votre Adresse e-mail et votre Mot de passe.", "Erreur");

            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continuer") { Id = 0 });

            dialog.DefaultCommandIndex = 0;

            var result = await dialog.ShowAsync();
        }
    }
}
