using Métier2;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AffichageHeuresConduites : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        int testInt;

        public AffichageHeuresConduites()
        {
            this.InitializeComponent();
            DataContext = Manager;
            testInt = TestListe.SelectedIndex;
        }

        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            Manager.SelectedDate = Calendrier.SelectedDates;
        }

        private void AjouterHeure(object sender, RoutedEventArgs e)
        {
            Manager.SelectedIndexHeureConduite = -1;
            this.Frame.Navigate(typeof(ModifierHeureConduite));
        }

        private void ModifierHeure(object sender, RoutedEventArgs e)
        {
            if (Manager.SelectedIndexHeureConduite == -1) return;
            var compte = Manager.CompteCourant as CompteEcole;
            Manager.SelectedIndexFormateur = compte.Formateurs.IndexOf(Manager.SelectedHeureConduite.Key.Item1);
            Manager.SelectedIndexProfil = Manager.CompteCourant.Profils.IndexOf(Manager.SelectedHeureConduite.Value.Item1);
            this.Frame.Navigate(typeof(ModifierHeureConduite));
        }

        private void SupprimerHeure(object sender, RoutedEventArgs e)
        {
            Manager.SupprimerHeureConduite();
        }
    }
}
