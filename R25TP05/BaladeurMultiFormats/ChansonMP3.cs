﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaladeurMultiFormats;

namespace BaladeurMultiFormatsTests
{
    public class ChansonMP3 : Chanson
    {
        public override string Format { get => "MP3"; }

        public ChansonMP3(string pNomFichier)
            : base(pNomFichier)
        {
            string[] tabChanson = pNomFichier.Split(':');
            m_titre = tabChanson[0];
            m_artiste = tabChanson[1];
            m_annee = int.Parse(tabChanson[2]);
        }

        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
            : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {
            m_titre = pTitre;
            m_artiste = pArtiste;
            m_annee = pAnnée;
            m_nomFichier = pTitre + "." + Format.ToLower();
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(m_artiste + "|" + m_annee.ToString("yyyy") + "|" + m_titre);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderAAC(pParoles));
        }

        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(m_nomFichier);
            ChansonMP3 chanson = new ChansonMP3(fichier.ReadLine().Trim());
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
    }
}
