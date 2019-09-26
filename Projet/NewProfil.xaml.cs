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

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class NewProfil : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        Profil profil;

        public NewProfil()
        {
            this.InitializeComponent();
            profil = new Profil("", "", DateTime.Today) { RdvPeda = DateTime.Today, NEPH = "", Permis = DateTime.Today };
        }

        private void Ajouter(object sender, RoutedEventArgs e)
        {
            Manager.AjouterProfil(profil);
            this.Frame.Navigate(typeof(AffichageCompte));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AffichageCompte));
        }
    }
}
