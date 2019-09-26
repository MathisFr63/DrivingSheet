using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Métier2
{
    /// <summary>
    /// Compte "normal" (fait pour les auto-écoles) et permettant à une auto-école de suivre l'avancée de ses élèves et de saisir des informations plus techniques sur chacun de ses élèves
    /// comme la date du permis de conduire, la date du prochain rendez-vous pédagogique, ou bien le numéro de dossier (NEPH).
    /// </summary>
    [DataContract, KnownType(typeof(CompteClient)), KnownType(typeof(CompteEcole))]
    public class Compte : INotifyPropertyChanged, IEquatable<Compte>
    {
        /// <summary>
        /// Informations relatives à chaque compte (l'identifiant et l'adresse Email doivent être unique).
        /// </summary>

        [DataMember]
        public string Email { get; private set; }
        [DataMember]
        public string MotDePasse { get; private set; }

        /// <summary>
        /// Permet de modifier les éléments de la liste de profils (ajouter/supprimer un profil) mais pas de modifier directement la liste !
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Profil> Profils { get; private set; } = new ObservableCollection<Profil>();

        /// <summary>
        /// Constructeur d'un compte.
        /// </summary>
        /// <param name="email">Email du compte</param>
        /// <param name="mdp">Mot de passe du compte</param>
        public Compte(string email, string mdp)
        {
            Email = email;
            MotDePasse = mdp;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Permet d'afficher la liste des profils ainsi que le nombre de kilomètres effectués par chacun sur la page XAML "Carnet" afin de choisir dans la ListView le profil voulu.
        /// </summary>
        public void afficheProfilKm()
        {
            Dictionary<string, int> dico = Profils.ToDictionary(p => $"{p.Nom} {p.Prenom}", p => p.KmTotaux);
            //foreach (var kvp in dico) WriteLine($"{kvp.Key} : {kvp.Value}");
            //WriteLine();
            //WriteLine();
        }

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Compte);
        }

        public bool Equals(Compte other)
        {
            return (this.Email == other.Email);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Email}";
        }
    }
}
