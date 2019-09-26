using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Métier2
{
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Compte CompteCourant { get; set; } = null;

        public IDataManager DataManager { get; set; }

        private int selectedIndexVoiture = -1;
        public int SelectedIndexVoiture
        {
            get { return selectedIndexVoiture; }
            set
            {
                selectedIndexVoiture = value;
                OnPropertyChanged(nameof(SelectedIndexVoiture));
                OnPropertyChanged(nameof(SelectedVoiture));
                OnPropertyChanged(nameof(KmVoiture));
            }
        }

        public Voiture SelectedVoiture
        {
            get
            {
                var compte = CompteCourant as CompteClient;
                return SelectedIndexVoiture >= 0 ? compte?.Voitures[SelectedIndexVoiture] : null;
            }
        }

        private int selectedIndexProfil = -1;
        public int SelectedIndexProfil
        {
            get { return selectedIndexProfil; }
            set
            {
                selectedIndexProfil = CompteCourant.Profils.Count == 0 ? -1 : value;
                OnPropertyChanged(nameof(SelectedIndexProfil));
                OnPropertyChanged(nameof(SelectedProfil));
                OnPropertyChanged(nameof(KmVoiture));
                OnPropertyChanged(nameof(SelectedIndexTrajet));
                OnPropertyChanged(nameof(ProchaineHeure));
            }
        }

        public Profil SelectedProfil
        {
            get
            {
                return SelectedIndexProfil >= 0 ? CompteCourant.Profils[SelectedIndexProfil] : null;
            }
        }


        private int selectedIndexFormateur = -1;
        public int SelectedIndexFormateur
        {
            get { return selectedIndexFormateur; }
            set
            {
                var compte = CompteCourant as CompteEcole;
                selectedIndexFormateur = compte.Formateurs.Count == 0 ? -1 : value;
                OnPropertyChanged(nameof(SelectedIndexFormateur));
                OnPropertyChanged(nameof(SelectedMoniteur));
                OnPropertyChanged(nameof(NbHeures));
            }
        }

        public Personne SelectedMoniteur
        {
            get
            {
                var compte = CompteCourant as CompteEcole;
                return SelectedIndexFormateur >= 0 ? compte.Formateurs[SelectedIndexFormateur] : null;
            }
        }

        private int selectedIndexFavori = -1;
        public int SelectedIndexFavori
        {
            get { return selectedIndexFavori; }
            set
            {
                selectedIndexFavori = value;
                OnPropertyChanged(nameof(SelectedIndexFavori));
                OnPropertyChanged(nameof(SelectedFavori));
            }
        }

        public Trajet SelectedFavori
        {
            get
            {
                var compte = CompteCourant as CompteClient;
                return SelectedIndexFavori >= 0 ? compte?.Favoris[SelectedIndexFavori] : null;
            }
        }


        private int selectedIndexTrajet = -1;
        public int SelectedIndexTrajet
        {
            get { return selectedIndexTrajet; }
            set
            {
                selectedIndexTrajet = value;
                OnPropertyChanged(nameof(SelectedIndexTrajet));
                OnPropertyChanged(nameof(SelectedTrajet));
            }
        }

        public Trajet SelectedTrajet
        {
            get
            {
                return SelectedIndexTrajet >= 0 && SelectedIndexTrajet < SelectedProfil.Trajets.Count ? SelectedProfil.Trajets[SelectedIndexTrajet] : null;
            }
        }

        private IList<DateTimeOffset> selectedDate = new List<DateTimeOffset>() { new DateTimeOffset(DateTime.Today) };
        public IList<DateTimeOffset> SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                OnPropertyChanged(nameof(ListeHeuresConduite));
            }
        }

        public Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> ListeHeuresConduite
        {
            get
            {
                var compte = CompteCourant as CompteEcole;
                if (selectedDate == null || selectedDate.Count <= 0) return null;
                Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> liste = new Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>>();
                foreach (var c in compte.Conduites)
                {
                    if (c.Key.Item2.Day.Equals(SelectedDate[0].Day))
                    {
                        liste.Add(c.Key, c.Value);
                    }
                }
                return liste;
                //return compte?.Conduites.Where(c => c.Key.Item2.Day.Equals(SelectedDate.Day));
            }
        }


        private int selectedIndexHeureConduite = -1;
        public int SelectedIndexHeureConduite
        {
            get { return selectedIndexHeureConduite; }
            set
            {
                selectedIndexHeureConduite = value;
                OnPropertyChanged(nameof(SelectedIndexHeureConduite));
                OnPropertyChanged(nameof(SelectedHeureConduite));
            }
        }

        public KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> SelectedHeureConduite
        {
            get
            {
                return SelectedIndexHeureConduite >= 0 && SelectedIndexHeureConduite < ListeHeuresConduite.Count ? ListeHeuresConduite.ElementAt(SelectedIndexHeureConduite) : new KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>>();
            }
        }

        public int KmVoiture
        {
            get
            {
                if (SelectedIndexProfil == -1) return 0;
                if (SelectedIndexVoiture == -1) return 0;
                if (SelectedVoiture == null) return 0;
                return SelectedProfil.Trajets.Where(t => t.Voiture.Equals(SelectedVoiture)).Sum(t => t.Km);
            }
        }


        public int NbHeures
        {
            get
            {
                var compte = CompteCourant as CompteEcole;
                if (SelectedIndexFormateur == -1) return 12;
                return compte.Conduites.Where(t => t.Key.Item1.Equals(SelectedMoniteur)).Sum(t => t.Value.Item2.Hours);
            }
        }

        public DateTime ProchaineHeure
        {
            get
            {
                var compte = CompteCourant as CompteEcole;
                return SelectedIndexProfil >= 0 && compte.Conduites.Where(c => c.Key.Item2 > DateTime.Today && c.Value.Item1.Equals(SelectedProfil)).Count() > 0 ? compte.Conduites.OrderBy(c => c.Key.Item2).FirstOrDefault(c => c.Key.Item2 > DateTime.Today && c.Value.Item1.Equals(SelectedProfil)).Key.Item2 : new DateTime();
            }
        }


        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Constructeur d'un Manager
        /// </summary>
        /// <param name="dataManager">DataManager permettant le chargement des données</param>
        public Manager(IDataManager dataManager)
        {
            DataManager = dataManager;
            //CompteCourant = DataManager.CompteData;
        }

        public void Sauvegarde()
        {
            DataManager.SaveChanges();
        }

        /// <summary>
        /// Connexion à un compte existant si il existe.
        /// </summary>
        /// <param name="email">Email de l'utilisateur</param>
        /// <param name="mdp">Mot de passe de l'utilisateur</param>
        public async Task<bool> Connexion(string email, string mdp)
        {
            DataManager.Connexion("", "");
            //if (!await DataManager.Connexion(email, mdp)) return false;
            CompteCourant = DataManager.CompteData;
            return true;
        }

        /// <summary>
        /// Inscrit un utilisateur dans la la base de donnée grâce à son email et à son mot de passe.
        /// </summary>
        /// <param name="email">Email de l'utilisateur</param>
        /// <param name="mdp">Mot de passe de l'utilisateur</param>
        public async Task<bool> Inscription(string email, string mdp, bool ecole)
        {
            if (!await DataManager.Inscription(email, mdp, ecole)) return false;
            CompteCourant = DataManager.CompteData;
            return true;
        }

        /// <summary>
        /// Ajoute un profil au compte de l'utilisateur
        /// </summary>
        /// <param name="profil">Profil à ajouter</param>
        public void AjouterProfil(Profil profil)
        {
            DataManager.AjouterProfil(profil);
        }

        /// <summary>
        /// Permet de supprimer un profil du compte
        /// </summary>
        public void SupprimerProfil()
        {
            DataManager.SupprimerProfil(SelectedProfil);
        }

        /// <summary>
        /// Permet de modifier les informations d'un profil.
        /// </summary>
        /// <param name="profil">Profil contenant les données que l'on veut modifier</param>
        public void ModifierProfil(Profil profil)
        {
            DataManager.ModifierProfil(SelectedProfil, profil);
        }

        /// <summary>
        /// Permet d'ajouter une voiture à un compte client.
        /// </summary>
        /// <param name="marque">Marque de la voiture</param>
        /// <param name="modele">Modèle de la voiture</param>
        /// <param name="immat">Immatriculation de la voiture</param>
        /// <param name="image">Image de la voiture</param>
        public void AjouterVoiture(Voiture voiture)
        {
            DataManager.AjouterVoiture(voiture);
        }

        /// <summary>
        /// Modifie les informations d'une voiture
        /// </summary>
        /// <param name="voiture">Voiture que l'on souhaite modifiée</param>
        public void ModifierVoiture(Voiture voiture)
        {
            DataManager.ModifierVoiture(SelectedVoiture, voiture);
        }

        /// <summary>
        /// Permet de supprimer une voiture d'un compte
        /// </summary>
        public void SupprimerVoiture()
        {
            DataManager.SupprimerVoiture(SelectedVoiture);
        }


        /// <summary>
        /// Permet d'ajouter un trajet à notre liste de trajets favoris
        /// </summary>
        /// <param name="trajet">Trajet à ajouter dans la lsite des trajets favoris</param>
        public void AjouterFavori(Trajet trajet)
        {
            DataManager.AjouterFavori(trajet);
        }

        /// <summary>
        /// Permet de supprimer un trajet de la liste de trajets favoris
        /// </summary>
        public void SupprimerFavori()
        {
            DataManager.SupprimerFavori(SelectedFavori);
        }


        /// <summary>
        /// Permet d'ajouter un trajet à un profil.
        /// </summary>
        /// <param name="trajet">Trajet que l'on veut ajouter au profil</param>
        public void AjouterTrajet(Trajet trajet)
        {
            DataManager.AjouterTrajet(SelectedProfil, trajet);
        }

        /// <summary>
        /// Permet d'ajouter un trajet à un profil.
        /// </summary>
        public void SupprimerTrajet()
        {
            DataManager.SupprimerTrajet(SelectedProfil, SelectedTrajet);
        }


        /// <summary>
        /// Ajoute au compte de l'utilisateur un moniteur contenant les informations transmises.
        /// </summary>
        /// <param name="moniteur">Moniteur que l'on veut ajouter</param>
        public void AjouterMoniteur(Personne moniteur)
        {
            DataManager.AjouterMoniteur(moniteur);
        }

        /// <summary>
        /// Permet de supprimer un formateur du compte
        /// </summary>
        public void SupprimerMoniteur()
        {
            DataManager.SupprimerMoniteur(SelectedMoniteur);
        }

        /// <summary>
        /// Permet de modifier les informations d'un moniteur.
        /// </summary>
        /// <param name="nom">Nom du moniteur</param>
        /// <param name="prenom">Prénom du moniteur</param>
        public void ModifierFormateur(Personne moniteur)
        {
            DataManager.ModifierMoniteur(SelectedMoniteur, moniteur);
        }


        /// <summary>
        /// Ajoute une heure de conduite au dictionnaire des heures de conduite de l'auto-école.
        /// </summary>
        /// <param name="moniteur">Formateur enseignant durant l'heure de conduite</param>
        /// <param name="date">Date à laquelle aura lieu l'heure de conduite</param>
        /// <param name="temps">Durée de l'heure de conduite</param>
        /// <param name="profil">Profil de l'élève prenant l'heure de conduite</param>
        public bool AjouterHeureConduite(DateTime date, TimeSpan temps)
        {
            bool result;
            result = DataManager.AjouterHeureConduite(SelectedMoniteur, date, temps, SelectedProfil);
            if (result)
                OnPropertyChanged(nameof(ListeHeuresConduite));
            return result;
        }

        /// <summary>
        /// Permet de modifier les informations d'une heure de conduite.
        /// </summary>
        /// <param name="temps">Durée de l'heure de conduite</param>
        public bool ModifierHeureConduite(DateTime date, TimeSpan durée)
        {
            var save = SelectedHeureConduite;
            if (SelectedIndexHeureConduite != -1)
                DataManager.SupprimerHeureConduite(SelectedHeureConduite);
            if (DataManager.AjouterHeureConduite(SelectedMoniteur, date, durée, SelectedProfil)) return true;
            DataManager.AjouterHeureConduite(save.Key.Item1, save.Key.Item2, save.Value.Item2, save.Value.Item1);
            return false;
        }

        /// <summary>
        /// Supprime une heure de conduite du dictionnaire des heures de conduite de l'auto-école.
        /// </summary>
        public void SupprimerHeureConduite()
        {
            DataManager.SupprimerHeureConduite(SelectedHeureConduite);
            OnPropertyChanged(nameof(ListeHeuresConduite));
        }
    }
}
