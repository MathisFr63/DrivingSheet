using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Métier2
{
    public interface IDataManager
    {
        //Compte CompteData { get; }
        Compte CompteData { get; set; }
        void AjouterProfil(Profil profil);
        void ModifierProfil(Profil SelectedProfil, Profil profil);
        void SupprimerProfil(Profil profil);
        void AjouterVoiture(Voiture voiture);
        void ModifierVoiture(Voiture SelectedVoiture, Voiture voiture);
        void SupprimerVoiture(Voiture voiture);
        void AjouterFavori(Trajet trajet);
        void SupprimerFavori(Trajet trajet);
        void AjouterTrajet(Profil SelectedProfil, Trajet trajet);
        void SupprimerTrajet(Profil SelectedProfil, Trajet trajet);
        void AjouterMoniteur(Personne moniteur);
        void SupprimerMoniteur(Personne moniteur);
        void ModifierMoniteur(Personne SelectedMoniteur, Personne moniteur);
        bool AjouterHeureConduite(Personne moniteur, DateTime date, TimeSpan temps, Profil profil);
        void SupprimerHeureConduite(KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> SelectedHeureConduite);

        Task<bool> Connexion(string id, string mdp);
        Task<bool> Inscription(string id, string mdp, bool ecole);
        Task SaveChanges();
    }
}