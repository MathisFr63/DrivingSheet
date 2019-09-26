using Métier2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace XmlData
{
    public class XmlDataManager : IDataManager
    {
        //string xmlFileName = "CompteEcole.xml";
        string xmlFileName = "compte.xml";
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        StorageFile xmlFile;
        StorageFile connexionFile;

        DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(Compte));
        DataContractSerializer SerializerComptes { get; set; } = new DataContractSerializer(typeof(Dictionary<string, int>));

        public Compte CompteData { get; set; }
        Dictionary<string, int> comptes;

        public XmlDataManager()
        {
            comptes = GetListeCompte().Result;
            CompteData = GetCompte().Result;
        }

        private async Task<Compte> GetCompte()
        {
            xmlFile = await storageFolder.CreateFileAsync(xmlFileName, CreationCollisionOption.OpenIfExists);

            Compte compte;
            using (Stream stream = await xmlFile.OpenStreamForReadAsync())
            {
                compte = Serializer.ReadObject(stream) as Compte;
            }
            string test = xmlFile.Path;
            return compte;
        }

        private async Task<Dictionary<string, int>> GetListeCompte()
        {
            connexionFile = await storageFolder.CreateFileAsync("connexion.xml", CreationCollisionOption.OpenIfExists);
            Dictionary<string, int> dico;
            using (Stream stream = await connexionFile.OpenStreamForReadAsync())
            {
                dico = SerializerComptes.ReadObject(stream) as Dictionary<string, int>;
            }
            return dico;
        }

        public async Task SaveListeCompte()
        {
            connexionFile = await storageFolder.CreateFileAsync("connexion.xml", CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await connexionFile.OpenStreamForWriteAsync())
            {
                SerializerComptes.WriteObject(stream, comptes);
            }
        }

        public async Task SaveChanges()
        {
            xmlFile = await storageFolder.CreateFileAsync(xmlFileName, CreationCollisionOption.ReplaceExisting);

            using (Stream stream = await xmlFile.OpenStreamForWriteAsync())
            {
                Serializer.WriteObject(stream, CompteData);
            }
        }

        public async Task<bool> Connexion(string id, string mdp)
        {
            //int LeMdp;
            //comptes.TryGetValue(id.ToLower(), out LeMdp);
            //if (!mdp.GetHashCode().Equals(LeMdp)) return false;

            //xmlFileName = $"{id.ToLower()}.xml";
            //CompteData = GetCompte().Result;

            //xmlFileName = "mathisfr63@gmail.com.xml";
            //CompteData = await GetCompte();
            //CompteData = GetCompte().Result;

            return true;
        }

        public async Task<bool> Inscription(string id, string mdp, bool ecole)
        {
            if (comptes.ContainsKey(id.ToLower())) return false;
            comptes.Add(id.ToLower(), mdp.GetHashCode());
            await SaveListeCompte();
            if (ecole) CompteData = new CompteEcole(id, mdp);
            else CompteData = new CompteClient(id, mdp);
            xmlFileName = $"{id.ToLower()}.xml";
            await SaveChanges();
            return true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void AjouterProfil(Profil profil)
        {
            CompteData.Profils.Add(profil);
            SaveChanges();
        }

        public void SupprimerProfil(Profil profil)
        {
            if (!CompteData.Profils.Contains(profil)) return;

            CompteData.Profils.Remove(profil);

            var compte = CompteData as CompteEcole;
            if (compte != null)
            {
                foreach (KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> h in compte.Conduites)
                {
                    if (h.Value.Item1.Equals(profil)) compte.Conduites.Remove(h.Key);
                }
            }
            SaveChanges();
        }

        public void ModifierProfil(Profil SelectedProfil, Profil profil)
        {
            SelectedProfil.Nom = profil.Nom;
            SelectedProfil.Prenom = profil.Prenom;

            if (!(CompteData is CompteEcole))
            {
                return;
            }
            SelectedProfil.Permis = profil.Permis;
            SelectedProfil.NEPH = profil.NEPH;
            SelectedProfil.RdvPeda = profil.RdvPeda;

            var compte = CompteData as CompteEcole;
            foreach (KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> h in compte.Conduites)
            {
                if (h.Value.Item1.Equals(SelectedProfil))
                {
                    h.Value.Item1.Nom = profil.Nom;
                    h.Value.Item1.Nom = profil.Nom;
                    h.Value.Item1.Prenom = profil.Prenom;
                    h.Value.Item1.Permis = profil.Permis;
                    h.Value.Item1.NEPH = profil.NEPH;
                    h.Value.Item1.RdvPeda = profil.RdvPeda;
                }
            }

            SaveChanges();
        }

        public void AjouterVoiture(Voiture voiture)
        {
            var compte = CompteData as CompteClient;
            compte?.Voitures.Add(voiture);
            SaveChanges();
        }

        public void ModifierVoiture(Voiture SelectedVoiture, Voiture voiture)
        {
            var compte = CompteData as CompteClient;
            compte.Voitures[compte.Voitures.IndexOf(SelectedVoiture)] = voiture;
            foreach (Profil p in compte.Profils)
            {
                foreach (Trajet t in p.Trajets)
                {
                    if (t.Voiture.Equals(SelectedVoiture)) t.Voiture = voiture;
                }
            }
            SaveChanges();
        }

        public void SupprimerVoiture(Voiture voiture)
        {
            var compte = CompteData as CompteClient;
            compte?.Voitures.Remove(voiture);
            SaveChanges();
        }


        public void AjouterFavori(Trajet trajet)
        {
            var compte = CompteData as CompteClient;
            compte?.Favoris.Add(trajet);
            SaveChanges();
        }

        public void SupprimerFavori(Trajet trajet)
        {
            var compte = CompteData as CompteClient;
            compte?.Favoris.Remove(trajet);
            SaveChanges();
        }


        public void AjouterTrajet(Profil SelectedProfil, Trajet trajet)
        {
            SelectedProfil.Trajets.Add(trajet);
            SaveChanges();
        }

        public void SupprimerTrajet(Profil SelectedProfil, Trajet trajet)
        {
            SelectedProfil.Trajets.Remove(trajet);
            SaveChanges();
        }


        public void AjouterMoniteur(Personne moniteur)
        {
            var compte = CompteData as CompteEcole;
            compte?.Formateurs.Add(moniteur);
            SaveChanges();
        }

        public void SupprimerMoniteur(Personne moniteur)
        {
            var compte = CompteData as CompteEcole;
            compte?.Formateurs.Remove(moniteur);
            foreach (KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> h in compte.Conduites)
            {
                if (h.Key.Item1.Equals(moniteur)) compte.Conduites.Remove(h.Key);
            }
            SaveChanges();
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
            SaveChanges();
        }


        public bool AjouterHeureConduite(Personne moniteur, DateTime date, TimeSpan temps, Profil profil)
        {
            var compte = CompteData as CompteEcole;
            if (moniteur == null || profil == null || temps.Equals(new TimeSpan())) return false;
            if (compte.Conduites.ContainsKey(new Tuple<Personne, DateTime>(moniteur, date))) return false;
            compte?.Conduites.Add(new Tuple<Personne, DateTime>(moniteur, date), new Tuple<Profil, TimeSpan>(profil, temps));
            SaveChanges();
            return true;
        }

        public void SupprimerHeureConduite(KeyValuePair<Tuple<Personne, DateTime>, Tuple<Profil, TimeSpan>> SelectedHeureConduite)
        {
            var compte = CompteData as CompteEcole;
            compte?.Conduites.Remove(SelectedHeureConduite.Key);
            SaveChanges();
        }
    }
}
