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
    /// Personne possédant un nom et un prénom
    /// </summary>
    [DataContract]
    public class Personne : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        private string nom = "";
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged(nameof(Nom)); }
        }

        [DataMember]
        private string prenom = "";
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; OnPropertyChanged(nameof(Prenom)); }
        }

        public string Image => $"{Prenom}-{Nom}";

        public Personne(string prenom, string nom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public override string ToString()
        {
            return $"{Prenom}-{Nom}";
        }
    }
}
