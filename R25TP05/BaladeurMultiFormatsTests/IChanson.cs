using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormatsTests
{
    interface IChanson
    {
        #region Propriétés
        /// <summary>
        /// Obtient l’année de création de la chanson 
        /// </summary>
        int Annee { get; }

        /// <summary>
        /// Obtient le nom de l’artiste ou du groupe ayant créé la chanson
        /// </summary>
        string Artiste { get; }

        /// <summary>
        /// Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        /// </summary>
        string Format { get; }

        /// <summary>
        /// Obtient le nom de fichier de la chanson
        /// </summary>
        string NomFichier { get; }

        /// <summary>
        /// Cette propriété calculée va obtenir les paroles de la chanson à partir d’un fichier texte
        /// </summary>
        string Paroles { get; }

        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        string Titre { get; }
        #endregion

        #region Méthodes
        void Ecrire(string pParoles);

        void EcrireEntete(StreamWriter pobjFichier);

        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        void LireEntete();

        string LireParoles(StreamReader pobjFichier);

        void SauterEntete(StreamReader pobjFichier);
        #endregion
    }
}
