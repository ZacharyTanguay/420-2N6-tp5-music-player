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
        public int NbChansons => throw new NotImplementedException();

        public void AfficherLesChansons(ListView pListView)
        {
            throw new NotImplementedException();
        }

        public Chanson ChansonAt(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConstruireLaListeDesChansons()
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersAAC(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }
    }
}
