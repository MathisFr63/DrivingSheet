using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Métier2
{
    /// <summary>
    /// Profil d'un enfant/élève en conduite accompagnée.
    /// </summary>
    [DataContract]
    public class Profil : Personne, INotifyPropertyChanged, IEquatable<Profil>
    {
        /// <summary>
        /// Liste de tous les trajets effectués en conduite accompagnée.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Trajet> Trajets { get; private set; } = new ObservableCollection<Trajet>();

        [DataMember]
        public DateTime Naissance { get; set; }
        [DataMember]
        public DateTime Creation { get; private set; }

        /// <summary>
        /// Nombre de kilomètres totaux parcourus en conduite accompagnée grâce à la somme des distances de chaque trajet effectué.
        /// </summary>
        //public int KmTotaux
        //{
        //    get {
        //        //int kmTotaux =0;
        //        //foreach (Trajet t in Traje&ts)
        //        //{
        //        //    kmTotaux += t.Km;
        //        //}
        //        //return kmTotaux;
        //        return Trajets.Sum(t => t.Km);
        //    }
        //}
        public int KmTotaux => Trajets.Sum(t => t.Km);

        /// <summary>
        /// Informations plus poussées du profil que seul un Compte (donc compte d'une auto-école) pourra modifié.
        /// </summary>
        [DataMember]
        public DateTime RdvPeda { get; set; }
        [DataMember]
        public DateTime Permis { get; set; }
        [DataMember]
        public string NEPH { get; set; }

        /// <summary>
        /// Constructeur par défaut d'un Profil.
        /// </summary>
        /// <param name="prenom">Prénom de la personne</param>
        /// <param name="nom">Nom de la personne</param>
        /// <param name="naissance">Date de naissance du profil</param>
        /// <param name="image">Image du profil</param>
        public Profil(string prenom, string nom, DateTime naissance) : base(prenom, nom)
        {
            Naissance = naissance;
            Creation = DateTime.Today;
        }

        /// <summary>
        /// Constructeur plus poussé d'un profil.
        /// </summary>
        /// <param name="prenom">Prénom de la personne</param>
        /// <param name="nom">Nom de la personne</param>
        /// <param name="naissance">Date de naissance du profil</param>
        /// <param name="rdvPeda">Date du prochain rendez-vous pédagogique</param>
        /// <param name="permis">Date du permis de conduire</param>
        /// <param name="image">Image du profil</param>
        public Profil(string prenom, string nom, DateTime naissance, DateTime rdvPeda, DateTime permis) : this(prenom, nom, naissance)
        {
            RdvPeda = rdvPeda;
            Permis = permis;
            NEPH = "Inconnu";
        }

        /// <summary>
        /// Checks if the "right" object is equal to this Profil or not
        /// </summary>
        /// <param name="right">The other object to be compared with this Profil</param>
        /// <returns>true if equals, false if not</returns>
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

            return this.Equals(right as Profil);
        }

        /// <summary>
        /// Checks if the "other" Profil is equal to this Profil or not
        /// </summary>
        /// <param name="other">The other Profil to be compared with this Profil</param>
        /// <returns>true if equals, false if not</returns>
        public bool Equals(Profil other)
        {
            return (this.Prenom == other.Prenom && this.Nom == other.Nom && this.Naissance == other.Naissance);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
