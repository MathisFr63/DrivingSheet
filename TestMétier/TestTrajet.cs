using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Métier2;

namespace TestMétier
{
    [TestClass]
    public class TestTrajet
    {
        [TestMethod]
        public void TrajetEqualTrajet()
        {
            /// Vérification pour voir si tous les éléments sont bien pris en comtpe lorsque l'on veut savoir si 2 trajets sont "égaux".
            Trajet t = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");

            Trajet t1 = new Trajet(new DateTime(1, 1, 1), "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t2 = new Trajet(DateTime.Today, "", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t3 = new Trajet(DateTime.Today, "Clermont", null, new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t4 = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(0, 0, 0), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t8 = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 500, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t5 = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "208", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t6 = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t7 = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "Accident sur la route");
            Trajet t9 = new Trajet(DateTime.Today, "Clermont", "Paris", new TimeSpan(4, 25, 32), 436, new Voiture("Peugeot", "207", "BW-006-CK"), Meteo.Soleil, Trafic.Dense, "");

            ///Vérification avec la date.
            Assert.AreNotEqual(t, t1);
            ///Vérification avec le lieu de départ.
            Assert.AreNotEqual(t, t2);
            ///Vérification avec le lieu d'arrivée.
            Assert.AreNotEqual(t, t3);
            ///Vérification avec la durée.
            Assert.AreNotEqual(t, t4);
            ///Vérification avec le nombre de kilomètres parcourus.
            Assert.AreNotEqual(t, t5);
            ///Vérification avec la voiture utilisée.
            Assert.AreNotEqual(t, t6);
            ///Vérification avec la météo.
            Assert.AreNotEqual(t, t7);
            ///Vérification avec le trafic.
            Assert.AreNotEqual(t, t8);
            ///Vérification avec les remarques.
            Assert.AreNotEqual(t, t9);
        }
    }
}
