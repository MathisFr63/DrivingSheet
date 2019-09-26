using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Métier2;

namespace TestMétier
{
    [TestClass]
    public class TestVoiture
    {
        [TestMethod]
        public void VoitureEqualVoiture()
        {
            Voiture v = new Voiture("Peugeot", "207", "BW-006-CK");
            Voiture v1 = new Voiture("Peugeot", "207", null);
            Voiture v2 = new Voiture("Peugeot", null, "BW-006-CK");
            Voiture v3 = new Voiture(null, "207", "BW-006-CK");

            //Vérificaion pour voir si l'immatricualtion de la voiture est bien prise en compte pour savoir si 2 voitures sont "égales".
            Assert.AreNotEqual(v, v1);

            //Vérificaion pour voir si le modèle de la voiture est bien pris en compte pour savoir si 2 voitures sont "égales".
            Assert.AreNotEqual(v, v2);

            //Vérificaion pour voir si la marque de la voiture est bien prise en compte pour savoir si 2 voitures sont "égales".
            Assert.AreNotEqual(v, v3);
        }
    }
}
