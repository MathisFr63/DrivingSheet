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
    /// Compte d'un utilisateur ayant un enfant en conduite accompagnée et remplissant le carnet de route (cette classe permet contrairement au compte normal
    /// qui est fait pour les auto-écoles d'avoir la possibilité d'ajouter des voitures et de remplir le carnet de route.
    /// </summary>
    [DataContract]
    public class CompteClient : Compte
    {
        /// <summary>
        /// Liste de voitures que possède l'utilisateur et pouvant être utilisées durant les trajets de conduite accompagnée.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Voiture> Voitures { get; private set; } = new ObservableCollection<Voiture>();

        /// <summary>
        /// Permet de modifier les éléments de la liste de favoris contenant les trajets favoris de l'utilisateur (ajouter/supprimer un trajet) mais pas de modifier directement la liste !
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Trajet> Favoris { get; private set; } = new ObservableCollection<Trajet>();

        /// <summary>
        /// Constructeur d'un CompteClient.
        /// </summary>
        /// <param name="email">Email du compte</param>
        /// <param name="mdp">Mot de passe du compte</param>
        public CompteClient(string email, string mdp) : base(email, mdp) { }
    }
}
