using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Métier2;
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
    public sealed partial class HomePage : Page
    {
        internal Manager Manager
        {
            get
            {
                return (App.Current as App).Manager;
            }
        }

        private static string debUri = "ms-appx://exDataBinding/Assets/";
        internal List<Part> Parts { get; set; } = new List<Part>
        {
            new Part() {ImageSource = new Uri($"{debUri}Profils.jpg", UriKind.RelativeOrAbsolute), Title="Profils", PageType=typeof(AffichageProfil)},
            new Part() {ImageSource = new Uri($"{debUri}VoitureIcône.jpg", UriKind.RelativeOrAbsolute), Title="Voiture", PageType=typeof(AffichageVoitures)},
            new Part() {ImageSource = new Uri($"{debUri}conduiteacc.jpg", UriKind.RelativeOrAbsolute), Title="Carnet", PageType=typeof(Carnet)},
            new Part() {ImageSource = new Uri($"{debUri}NewTrajet.jpg", UriKind.RelativeOrAbsolute), Title="Nouveau Trajet", PageType=typeof(NouveauTrajet)},
            new Part() {ImageSource = new Uri($"{debUri}Options.jpg", UriKind.RelativeOrAbsolute), Title="Compte", PageType=typeof(AffichageCompte)},
        };

        Part PartMoniteur = new Part() { ImageSource = new Uri($"{debUri}formateur.jpg", UriKind.RelativeOrAbsolute), Title = "Moniteurs", PageType = typeof(AffichageFormateur) };
        Part PartHeuresConduites = new Part() { ImageSource = new Uri($"{debUri}tableau.jpg", UriKind.RelativeOrAbsolute), Title = "Conduites", PageType = typeof(AffichageHeuresConduites) };

        public HomePage()
        {
            this.InitializeComponent();
            if (Manager.CompteCourant != null && Manager.CompteCourant.GetType() == typeof(CompteEcole))
            {
                Parts[1] = PartMoniteur;
                Parts[3] = PartHeuresConduites;
            }
        }

        private void PartsControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Part part = e.AddedItems.FirstOrDefault() as Part;
            if (part == null) return;
            PartFrame.Navigate(part.PageType);
        }
    }
}
