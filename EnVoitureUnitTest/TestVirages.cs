using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using EnVoiture;
using System.Collections.Generic;

namespace EnVoitureUnitTest
{
    //Localisation = new PointF((float)(Localisation.X + dblVitesse * Math.Sin(Angle)),
    //(float)(Localisation.Y - dblVitesse * Math.Cos(Angle)));
    [TestClass]
    public class TestVirages
    {

//===========================================================================
// Tests Gauche
//===========================================================================

        /*
         * 
         * Acceleration
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui accelere à gauche
        public void TestAccelerationGaucheDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.TournerGauche();
            
            Assert.AreEqual(voiture.Angle, -0.001, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 0.10F, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de voiture en mouvement qui accelere à gauche
        public void TestAccelerationGaucheDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.TournerGauche();

            Assert.AreEqual(voiture.Angle, -0.051, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 5.1F, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de voiture en mouvement negatif qui accelere à gauche
        public void TestAccelerationGaucheDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.TournerGauche();

            Assert.AreEqual(voiture.Angle, 0.049, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -4.9F, 1e-6);
        }

        [TestMethod]//Deuxième test vitesse et angle de voiture en mouvement qui accelere à gauche
        public void TestAccelerationGaucheDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.TournerGauche();

            Assert.AreEqual(voiture.Angle, -0.151, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 15.1F, 1e-6);
        }

        /*
         * 
         * Freinages
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui freine à gauche
        public void TestFreinageGaucheDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, -0.001, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -0.05, 1e-8);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui freine à gauche
        public void TestFreinageGaucheDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, -0.051, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 4.95, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui freine à gauche
        public void TestFreinageGaucheDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.049, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -5.05, 1e-6);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui freine à gauche
        public void TestFreinageGaucheDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, -0.151, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 14.95, 1e-6);
        }

        /*
         * 
         * Frottement
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui decelere à gauche
        public void TestFrottementGaucheDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, -0.001, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 0.08, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui decelere à gauche
        public void TestFrottementGaucheDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, -0.051, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 5.08, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui decelere à gauche
        public void TestFrottementGaucheDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.049, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -4.88, 1e-6);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui decelere à gauche
        public void TestFrottementGaucheDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.TournerGauche();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, -0.151, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 15.08, 1e-6);
        }
//===========================================================================
// Tests Droite
//===========================================================================

        /*
         * 
         * Acceleration
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui accelere à droite
        public void TestAccelerationDroiteDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.TournerDroite();

            Assert.AreEqual(voiture.Angle, 0.001, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 0.10, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui accelere à droite
        public void TestAccelerationDroiteDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.TournerDroite();

            Assert.AreEqual(voiture.Angle, 0.051, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 5.1, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui accelere à droite
        public void TestAccelerationDroiteDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.TournerDroite();

            Assert.AreEqual(voiture.Angle, -0.049, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -4.9, 1e-6);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui accelere à droite
        public void TestAccelerationDroiteDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.TournerDroite();

            Assert.AreEqual(voiture.Angle, 0.151, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 15.1, 1e-6);
        }

        /*
         * 
         * Freinages
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui freine à droite
        public void TestFreinageDroiteDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.001, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -0.05, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui freine à droite
        public void TestFreinageDroiteDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.051, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 4.95F, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui freine à droite
        public void TestFreinageDroiteDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, -0.049, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -5.05, 1e-6);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui freine à droite
        public void TestFreinageDroiteDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.151, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 14.95, 1e-6);
        }

        /*
         * 
         * Frottement
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui decelere à droite
        public void TestFrottementDroiteDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.001, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 0.08, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui decelere à droite
        public void TestFrottementDroiteDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.051, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 5.08, 1e-6);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui decelere à droite
        public void TestFrottementDroiteDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, -0.049, 1e-6);
            Assert.AreEqual(voiture.Vitesse, -4.88, 1e-6);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui decelere à droite
        public void TestFrottementDroiteDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.TournerDroite();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.151, 1e-6);
            Assert.AreEqual(voiture.Vitesse, 15.08, 1e-6);
        }
//===========================================================================
// Tests tout droit
//===========================================================================

        /*
         * 
         * Acceleration
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui accelere tout droit
        public void TestAccelerationToutDroitDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui accelere tout droit
        public void TestAccelerationToutDroitDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui accelere tout droit
        public void TestAccelerationToutDroitDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui accelere tout droit
        public void TestAccelerationToutDroitDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        /*
         * 
         * Freinages
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui freine tout droit
        public void TestFreinageToutDroitDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui freine tout droit
        public void TestFreinageToutDroitDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui freine tout droit
        public void TestFreinageToutDroitDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui freine tout droit
        public void TestFreinageToutDroitDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.Freiner();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        /*
         * 
         * Frottement
         * 
         */

        [TestMethod]//Test vitesse et angle de la voiture arretee qui decelere tout droit
        public void TestFrottementToutDroitDepartArrete()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Accelerer();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement qui decelere tout droit
        public void TestFrottementToutDroitDepartMouvement()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 5.0F;
            voiture.Accelerer();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Test vitesse et angle de la voiture en mouvement negatif qui decelere tout droit
        public void TestFrottementToutDroitDepartVitesseNegative()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = -5.0F;
            voiture.Accelerer();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }

        [TestMethod]//Deuxième test vitesse et angle de la voiture en mouvement qui decelere tout droit
        public void TestFrottementToutDroitDepartVitessesDifferentes()
        {
            Usager voiture = new Voiture(0, 0, 10, 20, 80);
            voiture.Vitesse = 15.0F;
            voiture.Accelerer();
            voiture.Ralentir();

            Assert.AreEqual(voiture.Angle, 0.0F);
            Assert.AreEqual(voiture.Vitesse, 0.10F);
        }
    }
}
