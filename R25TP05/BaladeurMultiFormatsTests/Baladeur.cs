using BaladeurMultiFormatsTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        private List<Chanson> m_colChansons;
        private const string NOM_RÉPERTOIRE = "Chansons";

        public int NbChansons => m_colChansons.Count();

        public void AfficherLesChansons(ListView pListView)
        {
            foreach (Chanson chanson in m_colChansons)
            {
                ListViewItem i = new ListViewItem(chanson.Artiste);
                
                i.SubItems.Add(chanson.Titre);
                i.SubItems.Add(chanson.Annee.ToString());
                i.SubItems.Add(chanson.Format);

                pListView.Items.Add(i);
            }

        }

        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
        }

        public void ConstruireLaListeDesChansons()
        {
            if (!Directory.Exists(NOM_RÉPERTOIRE))
                throw new DirectoryNotFoundException();

            DirectoryInfo d = new DirectoryInfo(NOM_RÉPERTOIRE);

            foreach (var f in d.GetFiles())
            {
                try
                {

                    string format = f.Name.Substring(f.Name.Length - 3).ToUpper();
                    switch (format)
                    {
                        case "AAC":
                            m_colChansons.Add(new ChansonAAC(f.Name));
                            break;
                        case "MP3":
                            m_colChansons.Add(new ChansonMP3(f.Name));
                            break;
                        case "WMA":
                            m_colChansons.Add(new ChansonWMA(f.Name));
                            break;
                    }
                }
                catch
                {

                }
            }

            m_colChansons = m_colChansons.OrderBy(chanson => chanson.Titre).ToList();
        }

        public void ConvertirVersAAC(int pIndex)
        {
            Chanson chanson = m_colChansons[pIndex];
            ChansonAAC chansonACC = new ChansonAAC("Chansons", chanson.Artiste, chanson.Titre, chanson.Annee);
            StreamWriter streamWriter = new StreamWriter(NOM_RÉPERTOIRE + "/" + chansonACC.NomFichier);
            chanson.Ecrire(chanson.Paroles);
            streamWriter.Close();
            File.Delete(NOM_RÉPERTOIRE + "/" + chanson.NomFichier);
            m_colChansons[pIndex] = chanson;
        }

    }
}
