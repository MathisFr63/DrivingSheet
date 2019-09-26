using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Métier2;
using System.Linq;
using System.Collections.Generic;
using StubData;

namespace TestMétier
{
    [TestClass]
    public class TestManager
    {
        public Manager MonManager = new Manager(new StubDataManager());

        [TestMethod]
        public void CompteDataIsNotNull()
        {
            Assert.IsNotNull(MonManager.DataManager.CompteData);
        }
        
        [TestMethod]
        public void CompteClientMethodes()
        {
            MonManager.CompteCourant = new CompteClient("test", "test");

            /// Ajout d'un profil
            Profil p = new Profil("Mathis", "Frizot", new DateTime(1998, 11, 09));
            MonManager.AjouterProfil(p);
            Assert.IsTrue(MonManager.CompteCourant.Profils.Contains(p));

            /// Essais sur les méthodes que seul un compte client peut utiliser
            var compte = MonManager.CompteCourant as CompteClient;

            /// Ajout d'une voiture
            Voiture v = new Voiture("Peugeot", "207", "BW-006-CK");
            MonManager.AjouterVoiture(new Voiture("Peugeot", "207", "BW-006-CK"));
            Assert.IsTrue(compte.Voitures.Contains(v));
            /// Suppression d'une voiture
            MonManager.SelectedIndexVoiture = compte.Voitures.Count - 1;
            MonManager.SupprimerVoiture();
            Assert.IsFalse(compte.Voitures.Contains(v));

            /// Ajout d'un trajet
            Trajet t = new Trajet(DateTime.Today, "Lempdes", "Clermont", new TimeSpan(0, 12, 15), 15, v, Meteo.Soleil, Trafic.Dense, null);
            MonManager.AjouterTrajet(new Trajet(DateTime.Today, "Lempdes", "Clermont", new TimeSpan(0, 12, 15), 15, v, Meteo.Soleil, Trafic.Dense, null));
            Assert.IsTrue(MonManager.CompteCourant.Profils.ElementAt(0).Trajets.Contains(t));
            /// Suppression d'un trajet
            MonManager.SelectedIndexTrajet = MonManager.CompteCourant.Profils[0].Trajets.Count() - 1;
            MonManager.SupprimerTrajet();
            Assert.IsFalse(MonManager.CompteCourant.Profils.ElementAt(0).Trajets.Contains(t));

            /// Suppression d'un profil
            MonManager.SelectedIndexProfil = MonManager.CompteCourant.Profils.Count() - 1;
            MonManager. SupprimerProfil();
            Assert.IsFalse(MonManager.CompteCourant.Profils.Contains(p));
        }

        [TestMethod]
        public void CompteEcoleMethodes()
        {
            Profil p = new Profil("Mathis", "Frizot", new DateTime(1998, 11, 09));

            /// Essais sur les méthodes que seul un compte ecole peut utiliser
            MonManager.CompteCourant = new CompteEcole("test", "test");
            var compte2 = MonManager.CompteCourant as CompteEcole;

            /// Ajout d'une heure de conduite
            Personne pers = new Personne("Jean", "Dupont");
            DateTime date = DateTime.Now;
            TimeSpan temps = new TimeSpan(2, 0, 0);
            Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> d = new Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>>();
            d.Add(new Tuple<Personne, DateTime>(pers, date), new Tuple<Profil, TimeSpan>(p, temps));
            MonManager.SelectedIndexProfil = MonManager.CompteCourant.Profils.IndexOf(p);
            MonManager.SelectedIndexFormateur = compte2.Formateurs.IndexOf(pers);
            MonManager.AjouterHeureConduite(date, temps);
            Assert.IsTrue(compte2.Conduites.Contains(d.ElementAt(0)));

            /// Suppression d'une heure de conduite
            MonManager.SelectedIndexHeureConduite = 0;
            MonManager.SupprimerHeureConduite();
            Assert.IsFalse(compte2.Conduites.Contains(d.ElementAt(0)));
        }
    }
}