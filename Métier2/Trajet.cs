using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Métier2
{
    /// <summary>
    /// Trajet effectué par un jeune en conduite accompagnée aucune des informations d'un trajet ne peut être modifiée. Si il y avait une erreur dans un trajet, il faudrait obligatoirement le recréer.
    /// </summary>
    [DataContract]
    public class Trajet : IEquatable<Trajet>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        private string depart;
        public string Depart
        {
            get { return depart; }
            set { depart = value; OnPropertyChanged(Depart); }
        }


        [DataMember]
        public string Arrivee { get; private set; }

        [DataMember]
        public TimeSpan Duree { get; private set; }

        [DataMember]
        public int Km { get; private set; }

        [DataMember]
        public Voiture Voiture { get; set; }

        [DataMember]
        public Meteo Meteo { get; set; }

        [DataMember]
        public Trafic Trafic { get; set; }

        //public enum Meteo : byte
        //{
        //    Ensoleillé,
        //    Pluie,
        //    Brouillard,
        //    Neige
        //}

        //public enum Trafic : byte
        //{
        //    Normal,
        //    Dense,
        //    Faible,
        //    TrèsDense,
        //    TrèsFaible
        //}

        [DataMember]
        public string Remarque { get; private set; }

        /// <summary>
        /// Constructeur d'un Trajet.
        /// </summary>
        /// <param name="date">Date du trajet</param>
        /// <param name="depart">Lieu de départ du trajet</param>
        /// <param name="arrivee">Lieu d'arrivée du trajet</param>
        /// <param name="duree">Durée du trajet</param>
        /// <param name="km">Nombre de kilomètres parcourus durant le trajet</param>
        /// <param name="voiture">Voiture utilisée lors du trajet</param>
        /// <param name="meteo">Météo durant le trajet</param>
        /// <param name="trafic">Trafic sur la route durant le trajet</param>
        /// <param name="remarque">Remarques à ajouter sur le trajet (ex : Accident sur la route)</param>
        public Trajet(DateTime date, string depart, string arrivee, TimeSpan duree, int km, Voiture voiture, Meteo meteo, Trafic trafic, string remarque)
        {
            Date = date;
            Depart = depart;
            Arrivee = arrivee;
            Duree = duree;
            Km = km;
            Voiture = voiture;
            Meteo = meteo;
            Trafic = trafic;
            Remarque = remarque;
        }

        /// <summary>
        /// Checks if the "right" object is equal to this Trajet or not
        /// </summary>
        /// <param name="right">The other object to be compared with this Trajet</param>
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

            return this.Equals(right as Trajet);
        }

        /// <summary>
        /// Checks if the "other" object is equal to this Trajet or not
        /// </summary>
        /// <param name="other">The other Trajet to be compared with this Trajet</param>
        /// <returns>true if equals, false if not</returns>
        public bool Equals(Trajet other)
        {
            return (this.Date == other.Date && this.Depart == other.Depart && this.Arrivee == other.Arrivee && this.Duree == other.Duree && this.Km == other.Km && this.Voiture.Equals(other.Voiture));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Méthode permettant de retourner les informations concernant le Trajet sous forme de châine de caractères.
        /// </summary>
        /// <returns>Chaîne de caractères contenant les informations du Trajet</returns>
        public override string ToString()
        {
            return $"{Depart} | {Arrivee}";
        }
    }
}
