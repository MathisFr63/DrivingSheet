using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Métier2
{
    /// <summary>
    /// Classe possédant toutes les informations d'une voiture que possède un utilisateur, et permettant de définir lors de la saisie d'un nouveau trajet quelle voiture a était utilisée.
    /// </summary>
    [DataContract]
    public class Voiture : IEquatable<Voiture>
    {
        [DataMember]
        public string Marque { get; set; }
        [DataMember]
        public string Modele { get; set; }
        [DataMember]
        public string Immat { get; set; }

        public string Image => $"{Modele}-{Immat}";

        /// <summary>
        /// Constructeur d'une Voiture.
        /// </summary>
        /// <param name="marque">Marque de la voiture</param>
        /// <param name="modele">Modèle de la voiture</param>
        /// <param name="immat">Immatriculation de la voiture</param>
        /// <param name="image">Image de la voiture</param>
        public Voiture(string marque, string modele, string immat)
        {
            Marque = marque;
            Modele = modele;
            Immat = immat;
        }

        /// <summary>
        /// Checks if the "right" object is equal to this Voiture or not
        /// </summary>
        /// <param name="right">The other object to be compared with this Voiture</param>
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

            return this.Equals(right as Voiture);
        }

        /// <summary>
        /// Checks if the "other" Voiture is equal to this Voiture or not
        /// </summary>
        /// <param name="other">The other Voiture to be compared with this Voiture</param>
        /// <returns>true if equals, false if not</returns>
        public bool Equals(Voiture other)
        {
            return (this.Modele == other.Modele && this.Marque == other.Marque && this.Immat == other.Immat);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Méthode permettant de retourner toutes les informations concernant la voiture sous forme de chaîne de caractères.
        /// </summary>
        /// <returns>Chaîne de caractères contenant les informations de la Voiture</returns>
        public override string ToString()
        {
            return $"{Modele}-{Immat}";
        }
    }
}
