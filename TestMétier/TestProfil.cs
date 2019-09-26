using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Métier2;

namespace TestMétier
{
    [TestClass]
    public class TestProfil
    {
        [TestMethod]
        public void ProfilEqualProfil()
        {
            Profil p = new Profil("Jean", "Dupont", new DateTime(2000, 1, 1));
            Profil p1 = new Profil("Jean", "Dupont", new DateTime(1, 1, 1));
            Profil p2 = new Profil("Jean", null, new DateTime(2000, 1, 1));
            Profil p3 = new Profil(null, "Dupont", new DateTime(2000, 1, 1));
            Profil p4 = new Profil("Jean", "Dupont", new DateTime(2000, 1, 1));

            //Vérification pour voir si la liste de trajets des profils ne sont pas nuls.
            Assert.IsNotNull(p.Trajets);

            //Vérification pour voir si la date de naissance du profil est bien pris en compte pour savoir si 2 profils sont "égaux".
            Assert.AreNotEqual(p, p1);

            //Vérification pour voir si la le nom du profil est bien pris en compte pour savoir si 2 profils sont "égaux".
            Assert.AreNotEqual(p, p2);

            //Vérification pour voir si le prénom du profil est bien pris en compte pour savoir si 2 profils sont "égaux".
            Assert.AreNotEqual(p, p3);

            ///Vérification pour voir la date du permis, la date du prochain rendez-vous et le numéro pédagogique du profil ne sont pas pris en compte pour savoir si 2 profils sont "égaux".
            p.Permis = DateTime.Today;
            p.RdvPeda = DateTime.Today;
            p.NEPH = "151213165141";
            Assert.AreEqual(p, p4);
        }
    }
}
