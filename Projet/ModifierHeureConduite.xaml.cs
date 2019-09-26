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
    public sealed partial class ModifierHeureConduite : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> Heure { get; set; }
        DateTimeOffset MaDate;
        TimeSpan MonHeure;
        TimeSpan MaDurée;

        public ModifierHeureConduite()
        {
            this.InitializeComponent();
            DataContext = Manager;
            if (Manager.SelectedIndexHeureConduite != -1)
            {
                Heure = Manager.SelectedHeureConduite;
                MaDate = DateTime.Now;
                MonHeure = MaDate.TimeOfDay;
            }
            else
            {
                var compte = Manager.CompteCourant as CompteEcole;
                Heure = new KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>>(new Tuple<Personne, DateTime>(compte.Formateurs[0], DateTime.Now), new Tuple<Profil, TimeSpan>(compte.Profils[0], new TimeSpan(0, 0, 0)));
            }
            MaDate = Heure.Key.Item2;
            MonHeure = Heure.Key.Item2.TimeOfDay;
            MaDurée = Heure.Value.Item2;
        }

        private async void Enregistrer(object sender, RoutedEventArgs e)
        {
            bool Vérif;
            if (Manager.SelectedIndexHeureConduite == -1)
                Vérif = Manager.AjouterHeureConduite(new DateTime(MaDate.Year, MaDate.Month, MaDate.Day, MonHeure.Hours, MonHeure.Minutes, MonHeure.Seconds), MaDurée);
            else
                Vérif = Manager.ModifierHeureConduite(new DateTime(MaDate.Year, MaDate.Month, MaDate.Day, MonHeure.Hours, MonHeure.Minutes, MonHeure.Seconds), MaDurée);
            if (!Vérif)
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Il est impossible d'ajouter cette heure de conduite car le moniteur a déjà une heure de conduite de prévue à cette heure là !", "Erreur");

                dialog.Commands.Add(new Windows.UI.Popups.UICommand("Continuer") { Id = 0 });

                dialog.DefaultCommandIndex = 0;

                var result = await dialog.ShowAsync();
            }
            else
                this.Frame.Navigate(typeof(AffichageHeuresConduites));
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AffichageHeuresConduites));
        }
    }
}
