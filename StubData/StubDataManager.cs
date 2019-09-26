using Métier2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubData
{
    public class StubDataManager : IDataManager
    {
        public CompteClient CompteClient { get; set; }
        public CompteEcole CompteEcole { get; set; }

        public Compte CompteData { get; set; }

        public StubDataManager()
        {
            CompteData = GetCompte();
        }

        public Compte GetCompte()
        {
            {
                CompteClient = new CompteClient("MathisFr63@gmail.com", "test");
                CompteEcole = new CompteEcole("MathisFr63@gmail.com", "test");

                Profil Profil1 = new Profil("Mathis", "Frizot", new DateTime(1998, 11, 09));
                Profil Profil2 = new Profil("Alexis", "Frizot", new DateTime(2000, 09, 21));
                Profil Profil3 = new Profil("Colin", "Frizot", new DateTime(2005, 08, 25));

                Personne Formateur1 = new Personne("Jean", "Dupont");
                Personne Formateur2 = new Personne("Marie", "Martin");
                Personne Formateur3 = new Personne("Kévin", "Clément");

                Voiture Voiture1 = new Voiture("Peugeot", "207", "BW-006-CK");
                Voiture Voiture2 = new Voiture("Citroën", "C3", "AA-000-AA");
                Voiture Voiture3 = new Voiture("Renault", "Mégane", "AA-000-AA");

                Trajet Trajet1 = new Trajet(DateTime.Today, "Clermont", "Lempdes", new TimeSpan(0, 15, 12), 15, Voiture1, Meteo.Soleil, Trafic.Dense, "");
                Trajet Trajet2 = new Trajet(DateTime.Today, "Lempdes", "Cournon", new TimeSpan(0, 5, 30), 5, Voiture1, Meteo.Soleil, Trafic.TrèsFaible, "");
                Trajet Trajet3 = new Trajet(DateTime.Today, "Lempdes", "Port-Leucate", new TimeSpan(4, 5, 12), 421, Voiture1, Meteo.Soleil, Trafic.Normal, "");

                CompteClient.Profils.Add(Profil1);
                CompteClient.Profils.Add(Profil2);
                CompteClient.Profils.Add(Profil3);

                CompteClient.Voitures.Add(Voiture1);
                CompteClient.Voitures.Add(Voiture2);
                CompteClient.Voitures.Add(Voiture3);

                CompteClient.Favoris.Add(Trajet1);
                CompteClient.Favoris.Add(Trajet2);
                CompteClient.Favoris.Add(Trajet3);
                CompteClient.Profils[0].Trajets.Add(Trajet1);
                CompteClient.Profils[0].Trajets.Add(Trajet2);
                CompteClient.Profils[0].Trajets.Add(Trajet3);

                CompteClient.Profils[1].Trajets.Add(Trajet1);
                CompteClient.Profils[1].Trajets.Add(Trajet2);

                CompteClient.Profils[2].Trajets.Add(Trajet3);

                CompteEcole.Profils.Add(Profil1);
                CompteEcole.Profils.Add(Profil2);
                CompteEcole.Profils.Add(Profil3);

                CompteEcole.Formateurs.Add(Formateur1);
                CompteEcole.Formateurs.Add(Formateur2);
                CompteEcole.Formateurs.Add(Formateur3);

                CompteEcole.Profils[0].Trajets.Add(Trajet1);
                CompteEcole.Profils[0].Trajets.Add(Trajet2);
                CompteEcole.Profils[0].Trajets.Add(Trajet3);

                CompteEcole.Profils[1].Trajets.Add(Trajet1);
                CompteEcole.Profils[1].Trajets.Add(Trajet2);

                CompteEcole.Profils[2].Trajets.Add(Trajet3);

                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur1, DateTime.Today), new Tuple<Profil, TimeSpan>(Profil1, new TimeSpan(2, 10, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur1, DateTime.Today.AddDays(-1)), new Tuple<Profil, TimeSpan>(Profil2, new TimeSpan(2, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur1, DateTime.Today.AddHours(4)), new Tuple<Profil, TimeSpan>(Profil3, new TimeSpan(1, 0, 0)));

                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur2, DateTime.Today.AddDays(-3)), new Tuple<Profil, TimeSpan>(Profil1, new TimeSpan(4, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur2, DateTime.Today.AddDays(-1)), new Tuple<Profil, TimeSpan>(Profil2, new TimeSpan(2, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur2, DateTime.Today), new Tuple<Profil, TimeSpan>(Profil3, new TimeSpan(1, 0, 0)));

                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur3, DateTime.Today.AddDays(4)), new Tuple<Profil, TimeSpan>(Profil1, new TimeSpan(2, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur3, DateTime.Today), new Tuple<Profil, TimeSpan>(Profil1, new TimeSpan(1, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur3, DateTime.Today.AddDays(-1)), new Tuple<Profil, TimeSpan>(Profil2, new TimeSpan(2, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur3, DateTime.Today.AddHours(2)), new Tuple<Profil, TimeSpan>(Profil3, new TimeSpan(1, 0, 0)));
                CompteEcole.Conduites.Add(new Tuple<Personne, DateTime>(Formateur3, DateTime.Today.AddDays(2)), new Tuple<Profil, TimeSpan>(Profil3, new TimeSpan(3, 0, 0)));

                return CompteClient as CompteClient;
                //return CompteEcole as CompteEcole;
            }
        }


        public void AjouterProfil(Profil profil)
        {
            CompteData.Profils.Add(profil);
        }

        public void ModifierProfil(Profil SelectedProfil, Profil profil)
        {
            //CompteData.Profils[CompteData.Profils.IndexOf(SelectedProfil)]

            SelectedProfil.Nom = profil.Nom;
            SelectedProfil.Prenom = profil.Prenom;

            if (!(CompteData is CompteEcole))
            {
                return;
            }
            SelectedProfil.Permis = profil.Permis;
            SelectedProfil.NEPH = profil.NEPH;
            SelectedProfil.RdvPeda = profil.RdvPeda;
        }

        public void SupprimerProfil(Profil profil)
        {
            CompteData.Profils.Remove(profil);
        }


        public void AjouterVoiture(Voiture voiture)
        {
            var compte = CompteData as CompteClient;
            compte?.Voitures.Add(voiture);
        }

        public void ModifierVoiture(Voiture SelectedVoiture, Voiture voiture)
        {
            SelectedVoiture.Marque = voiture.Marque;
            SelectedVoiture.Modele = voiture.Modele;
            SelectedVoiture.Immat = voiture.Immat;
        }

        public void SupprimerVoiture(Voiture voiture)
        {
            var compte = CompteData as CompteClient;
            compte?.Voitures.Remove(voiture);
        }


        public void AjouterFavori(Trajet trajet)
        {
            var compte = CompteData as CompteClient;
            compte?.Favoris.Add(trajet);
        }

        public void SupprimerFavori(Trajet trajet)
        {
            var compte = CompteData as CompteClient;
            compte?.Favoris.Remove(trajet);
        }


        public void AjouterTrajet(Profil SelectedProfil, Trajet trajet)
        {
            SelectedProfil.Trajets.Add(trajet);
        }

        public void SupprimerTrajet(Profil SelectedProfil, Trajet trajet)
        {
            SelectedProfil.Trajets.Remove(trajet);
        }


        public void AjouterMoniteur(Personne moniteur)
        {
            var compte = CompteData as CompteEcole;
            compte?.Formateurs.Add(moniteur);
        }

        public void SupprimerMoniteur(Personne moniteur)
        {
            var compte = CompteData as CompteEcole;
            compte?.Formateurs.Remove(moniteur);
        }

        public void ModifierMoniteur(Personne SelectedMoniteur, Personne moniteur)
        {
            if (SelectedMoniteur != null)
            {
                SelectedMoniteur.Prenom = moniteur.Prenom;
                SelectedMoniteur.Nom = moniteur.Nom;
            }
            else
                AjouterMoniteur(moniteur);
        }


        public bool AjouterHeureConduite(Personne moniteur, DateTime date, TimeSpan temps, Profil profil)
        {
            var compte = CompteData as CompteEcole;
            if (compte.Conduites.ContainsKey(new Tuple<Personne, DateTime>(moniteur, date))) return false;
            compte?.Conduites.Add(new Tuple<Personne, DateTime>(moniteur, date), new Tuple<Profil, TimeSpan>(profil, temps));
            return true;
        }

        public void SupprimerHeureConduite(KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> SelectedHeureConduite)
        {
            var compte = CompteData as CompteEcole;
            compte?.Conduites.Remove(SelectedHeureConduite.Key);
        }


        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Connexion(string id, string mdp)
        {
            return new Task<bool>(() => true);
        }

        public Task<bool> Inscription(string id, string mdp, bool ecole)
        {
            throw new NotImplementedException();
        }
    }
}
