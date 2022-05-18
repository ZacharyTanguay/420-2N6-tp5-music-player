using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace BaladeurMultiFormatsTests
{
    [TestClass]
    public class UnitTestHistoriqueTODOs
    {

        #region Tests de la méthode NbConsultationDepuisXSecondes
        // TODO Test E : HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest
        // Compléter la méthode pour tester le cas où la valeur du délai passé en paramètre est négative
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest()
        {
            // Arrange : Instancier un objet Historique
            // À compléter...
            Historique historique = new Historique();

            // Act : Appeler la méthode NbConsultationsDepuisXSecondes
            // À compléter...
            historique.NbConsultationsDepuisXSecondes(-1);

            // Assert : Vérifier si la méthode lève une exception IndexOutOfRangeException
            // À compléter...
        }


        // TODO Test F : HistoriqueTestNbConsultationDepuisXSecondesValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod]
        public void HistoriqueTestNbConsultationDepuisXSecondesValideTest()
        {
            // Arrange : Instancier un objet Historique et y ajouter trois consultations d'une même chansonAAC
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // À compléter...
            Historique historique = new Historique();
            ChansonAAC chanson = new ChansonAAC("Chansons");
            foreach (var file in new DirectoryInfo("Chansons").GetFiles())
            {
                if (file.Name.EndsWith("aac"))
                {
                    chanson = new ChansonAAC("Chansons/" + file.Name);
                    continue;
                }
            }
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-100), chanson));
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-150), chanson));
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-300), chanson));



            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de chansons consultées depuis 200 secondes.
            // À compléter...
            int i = historique.NbConsultationsDepuisXSecondes(200);

            // Assert : Vérifier si la méthode retourne le bon nombre de consultations qui est 2 !
            // À compléter...
            Assert.AreEqual(i, 2);

        }
        #endregion

        #region Tests de la méthode NbConsultationsPourUneChanson
        // TODO Test G : HistoriqueTestNbConsultationsPourUneChansonParamNullTest
        // Compléter la méthode pour tester le cas où la chanson passée en paramètre est à null
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HistoriqueTestNbConsultationsPourUneChansonParamNullTest()
        {
            // Arrange : Instancier un objet Historique
            // À compléter...
            Historique historique = new Historique();


            // Act : Appeler la méthode NbConsultationsDepuisXSecondes en lui passant la valeur null
            // À compléter...

            //change pour NbConsultationsPourUneChanson car int est non-nullable.
            historique.NbConsultationsPourUneChanson(null);

            // Assert : Vérifier si la méthode lève une exception ArgumentNullException
            // À compléter...
        }

        // TODO Test H : HistoriqueTestNbConsultationsPourUneChansonValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod]
        public void HistoriqueTestNbConsultationsPourUneChansonValideTest()
        {
            // Arrange : Instancier un objet Historique et un objet ChansonAAC
            // Ajouter quatre consultations de cette même chansonAAC dans l'objet Historique
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // La quatrième consultation depuis 350 secondes (DateTime.AddSeconds(-350))
            // À compléter...
            Historique historique = new Historique();
            ChansonAAC chanson = new ChansonAAC("Chansons");
            foreach (var file in new DirectoryInfo("Chansons").GetFiles())
            {
                if(file.Name.EndsWith("aac"))
                {
                    chanson = new ChansonAAC("Chansons/" + file.Name);
                    continue;
                }
            }
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-100), chanson));
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-150), chanson));
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-300), chanson));
            historique.Add(new Consultation(DateTime.Now.AddSeconds(-350), chanson));



            // Act : Appeler la méthode NbConsultationsPourUneChanson pour calculer le nombre 
            // de fois que la chansonAAC a été consultée.
            // À compléter...
            int i = historique.NbConsultationsPourUneChanson(chanson);

            // Assert : Vérifier si la méthode retourne la bon nombre de consultations qui est 4
            // À compléter...
            Assert.AreEqual(i, 4);



        }


        #endregion
    }
}