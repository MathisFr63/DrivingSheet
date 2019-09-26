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
    public sealed partial class ModifierProfil : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        Profil profil;

        public ModifierProfil()
        {
            this.InitializeComponent();
            DataContext = Manager;
            profil = new Profil(Manager.SelectedProfil.Prenom, Manager.SelectedProfil.Nom, Manager.SelectedProfil.Naissance) { RdvPeda = Manager.SelectedProfil.RdvPeda, NEPH = Manager.SelectedProfil.NEPH, Permis = Manager.SelectedProfil.Permis };
        }

        private void Sauvegarde(object sender, RoutedEventArgs e)
        {
            Manager.ModifierProfil(profil);
            Frame.Navigate(typeof(AffichageProfil));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AffichageProfil));
        }
    }
}
