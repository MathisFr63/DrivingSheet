using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Métier2
{
    /// <summary>
    /// Compte d'une auto-école lui permettant de mettre à jour ses rendez-vous pédagogiques et ses heures de conduites.
    /// </summary>
    [DataContract]
    public class CompteEcole : Compte
    {
        /// <summary>
        /// Dictionnaire des prochaines heures de conduites prévues.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> Conduites { get; set; } = new Dictionary<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>>();

        /// <summary>
        /// Liste des formateurs travaillant pour l'auto-école.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Personne> Formateurs { get; private set; } = new ObservableCollection<Personne>();

        /// <summary>
        /// Constructeur d'un CompteEcole.
        /// </summary>
        /// <param name="id">Identifiant du compte</param>
        /// <param name="email">Email du compte</param>
        /// <param name="mdp">Mot de passe du compte</param>
        public CompteEcole(string email, string mdp) : base(email, mdp) { }

        /// <summary>
        /// Méthode permettant de retourner la somme des heures de conduites faites par un formateur.
        /// </summary>
        /// <param name="Formateur">Formateur dont on veut connaître la somme des heures de conduites</param>
        /// <returns>Nombre d'heures de conduites faites par le formateur</returns>
        //public int HeuresTotales(Personne Formateur)
        //{
        //    int Heures = 0;
        //    foreach (var t in Conduites.Keys)
        //    {
        //        if (t.Item1.Equals(Formateur))
        //            Heures += t.Item3.Hours;
        //    }
        //    return Heures;
        //}
    }
}
