using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Collections;
using ProiectPIU;


namespace ProiectPIU
{
    public class Adminbuget
    {
        private string numefisier;
        private const int Nr_max = 30;

       public Adminbuget()
        {

        }
        public void AddBuget(Buget buget)
        {
            using (StreamWriter streamWriterfisiertext = new StreamWriter(numefisier, true))
            {
                streamWriterfisiertext.WriteLine(buget.conversielasirptfisier());
            }
        }
        public Adminbuget(string _numefisier)
        {
            numefisier = _numefisier;
            Stream StreamFisieretext = File.Open(numefisier, FileMode.OpenOrCreate);
            StreamFisieretext.Close();

        }

        public ArrayList Get_bugete()
        {
            ArrayList bugete = new ArrayList();
            using (StreamReader streamReader = new StreamReader(numefisier))
            {
                string linie_fisier;
                while ((linie_fisier = streamReader.ReadLine()) != null)
                {
                    Buget buget1 = new Buget(linie_fisier);
                    bugete.Add(buget1);
                }
            }
            return bugete;

        }
        public Buget[] GetBuget(out int nrbugete)
        {
            Buget[] bugete = new Buget[Nr_max];
            using (StreamReader Streader = new StreamReader(numefisier))
            {
                string liniefisier;
                nrbugete = 0;
                while((liniefisier=Streader.ReadLine())!=null)
                {
                    bugete[nrbugete++] = new Buget(liniefisier);
                }
            }
            return bugete;
        }
    }
}
