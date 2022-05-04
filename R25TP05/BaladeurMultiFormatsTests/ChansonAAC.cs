using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaladeurMultiFormats;

namespace BaladeurMultiFormatsTests
{
    public class ChansonAAC : Chanson
    {
        #region Propriétés
        public override string Format { get => "AAC"; }
        #endregion


        #region Méthodes
        public ChansonAAC(string pNomFichier)
            :base(pNomFichier)
        {
            string[] tabChanson = pNomFichier.Split(':');
            m_titre = tabChanson[0];
            m_artiste = tabChanson[1];
            m_annee = int.Parse(tabChanson[2]);
        }

        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
            :base(pRepertoire, pArtiste, pTitre, pAnnée)
        {
            
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(m_titre + ":" + m_artiste + ":" + m_annee.ToString("yyyy"));
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderAAC(pParoles));
        }

        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(m_nomFichier);
            ChansonAAC chanson = new ChansonAAC(fichier.ReadLine().Trim());
            m_titre = chanson.Titre;
            m_artiste = chanson.Artiste;
            m_annee = chanson.Annee;
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            SauterEntete(pobjFichier);
            string fichier = pobjFichier.ReadToEnd();
            return OutilsFormats.DecoderAAC(fichier);
        }
        #endregion
    }
}
