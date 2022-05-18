using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaladeurMultiFormats;

namespace BaladeurMultiFormatsTests
{
    public interface IBaladeur
    {
        int NbChansons { get; }

        void AfficherLesChansons(ListView pListView);

        Chanson ChansonAt(int pIndex);

        void ConstruireLaListeDesChansons();

        void ConvertirVersAAC(int pIndex);

        void ConvertirVersMP3(int pIndex);

        void ConvertirVersWMA(int pIndex);
    }
}
