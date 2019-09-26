using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Métier2;

namespace TestMétier
{
    [TestClass]
    public class TestCompte
    {
        CompteClient MonCompte = new CompteClient("mathisfr63@gmail.com", "MotDePasse");
        Trajet test = new Trajet(DateTime.Today, "test", "test", new TimeSpan(0, 15, 25), 265, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident");

        //public void TestAddProfil()
        //{
        //    MonCompte.Profils.Add(new Profil("Jean", "Dupont", new DateTime(2000, 1, 1), new Uri("/Assets/Visage.jpg", UriKind.RelativeOrAbsolute)));
        //}

        //public void TestAddVoiture()
        //{
        //    MonCompte.Voitures.Add(new Voiture("Peugeot", "207", "BW-006-CK", new Uri("/Assets/VoitureIcône.jpg", UriKind.RelativeOrAbsolute)));
        //}

        //public void TestAddTrajet()
        //{
        //    MonCompte.Profils.ElementAt(0).Trajets.Add(new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK", new Uri("/Assets/VoitureIcône.jpg", UriKind.RelativeOrAbsolute)), "Soleil", "Dense", "Accident sur la route"));
        //}

        [TestMethod]
        public void CompteNonNul()
        {
            //Vérification pour voir si notre compte est nul à l'initialisation.
            Assert.IsNotNull(MonCompte);
        }

        [TestMethod]
        public void EmailNonNulVide()
        {
            //Vérification pour voir si notre email est nul ou vide à l'initialisation.
            Assert.IsNotNull(MonCompte.Email);
            Assert.AreNotEqual("", MonCompte.Email);
        }

        [TestMethod]
        public void MotdepasseNonNulVide()
        {
            //Vérification pour voir si notre mot de passe est nul ou vide à l'initialisation.
            Assert.IsNotNull(MonCompte.MotDePasse);
            Assert.AreNotEqual("", MonCompte.MotDePasse);
        }

        [TestMethod]
        public void ListeVide()
        {
            //Vérification pour voir si notre liste de voitures et bien initialiser correctement dès la création du compte.
            Assert.IsNotNull(MonCompte.Voitures);
          
            //Vérification pour voir si notre liste de profils et bien initialiser correctement dès la création du compte.
            Assert.IsNotNull(MonCompte.Profils);
        }

        //[TestMethod]
        //public void TestListVoiture()
        //{
        //    TestAddVoiture();
        //    Voiture v = MonCompte.Voitures.ElementAt(0);

        //    //Vérification pour voir si le premier élément de notre liste de voitures est bien égal à une voiture comportant les mêmes données.
        //    Assert.AreEqual(MonCompte.Voitures.ElementAt(0), new Voiture("Peugeot", "207", "BW-006-CK", new Uri("/Assets/VoitureIcône.jpg", UriKind.RelativeOrAbsolute)));
           
        //    //Vérification pour voir si la liste de nos voitures contient bien une voiture égale à la voiture que l'on vient d'ajouter. 
        //    Assert.IsTrue(MonCompte.Voitures.Contains(new Voiture("Peugeot", "207", "BW-006-CK", new Uri("/Assets/VoitureIcône.jpg", UriKind.RelativeOrAbsolute))));
            
        //    //Vérification pour voir si la liste de nos voitures contient bien la voiture que l'on vient d'ajouter.
        //    Assert.IsTrue(MonCompte.Voitures.Contains(v));
        //}

        //[TestMethod]
        //public void TestListProfil()
        //{
        //    TestAddProfil();
        //    Profil p = MonCompte.Profils.ElementAt(0);

        //    //Vérification pour voir si le premier élément de notre liste de voitures est bien égal à une voiture comportant les mêmes données.
        //    Assert.AreEqual(MonCompte.Profils.ElementAt(0), new Profil("Jean", "Dupont", new DateTime(2000,1,1), new Uri("/Assets/Visage.jpg", UriKind.RelativeOrAbsolute)));
         
        //    //Vérification pour voir si la liste de nos voitures contient bien une égale à la voiture que l'on vient d'ajouter. 
        //    Assert.IsTrue(MonCompte.Profils.Contains(new Profil("Jean", "Dupont", new DateTime(2000, 1, 1), new Uri("/Assets/Visage.jpg", UriKind.RelativeOrAbsolute))));
          
        //    //Vérification pour voir si la liste de nos voitures contient bien la voiture que l'on vient d'ajouter.
        //    Assert.IsTrue(MonCompte.Profils.Contains(p));
        //}
    }
}
