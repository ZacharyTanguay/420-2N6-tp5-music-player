using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormatsTests
{
    abstract class Chanson : IChanson
    {
        #region Champs
        private int m_annee;
        private string m_artiste;
        private string m_nomFichier;
        protected string m_titre;
        #endregion

        #region Propriétés
        /// <summary>
        /// Obtient l’année de création de la chanson 
        /// </summary>
        public int Annee { get => m_annee; }

        /// <summary>
        /// //Obtient le nom de l’artiste
        /// </summary>
        public string Artiste { get => m_artiste; }

        /// <summary>
        /// Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        /// </summary>
        public abstract string Format { get; }

        /// <summary>
        /// Obtient le nom de fichier de la chanson
        /// </summary>
        public string NomFichier { get => m_nomFichier; }

        /// <summary>
        /// Cette propriété calculée va vérifier si le fichier de la chanson existe, 
        /// afin de l'ouvrir pour ensuite sauter l'en-tête pour lire les paroles 
        /// les traiter et les retourner.
        /// </summary>
        public string Paroles { get; }

        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        public string Titre { get => m_titre; }
        #endregion

        #region Méthodes
        /// <summary>
        /// Initialise une instance, elle appelle la méthode LireEntete
        /// </summary>
        /// <param name="pNomFichier"></param>
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_nomFichier = pRepertoire;
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnée;
        }

        public void Ecrire(string pParoles)
        {
            StreamWriter fichier = new StreamWriter(NomFichier);
            EcrireEntete(fichier);
            EcrireParoles(fichier, pParoles);
        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);

        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        public abstract void LireEntete();

        public abstract string LireParoles(StreamReader pobjFichier);

        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }
        #endregion
    }
}
