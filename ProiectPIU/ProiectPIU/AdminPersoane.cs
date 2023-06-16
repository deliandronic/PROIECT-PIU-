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
   public  class AdminPersoane
    {
        private string numefisier;
        private const int Nr_max1 = 30;

        public void AddPersoana(Persoana persoana)
        {
            using (StreamWriter streamWriter_persoana = new StreamWriter(numefisier, true))
            {
                streamWriter_persoana.WriteLine(persoana.conversie_la_sir_pentru_fisier());
            }
        }
        public AdminPersoane(string _numefisier)
        {
            numefisier = _numefisier;
            Stream StreamFisieretext_pers = File.Open(numefisier, FileMode.OpenOrCreate);
            StreamFisieretext_pers.Close();

        }
        public ArrayList Get_persoane()
        {
            ArrayList persoane = new ArrayList();
            using (StreamReader streamReader = new StreamReader(numefisier))
            {
                string linie_fisier;
                while ((linie_fisier = streamReader.ReadLine()) != null)
                {
                    Persoana persoana = new Persoana(linie_fisier);
                    persoane.Add(persoana);
                }
            }
            return persoane;

        }
        public Persoana[] Get_Persoana(out int nr_persoane)
        {
            Persoana[] persoane = new Persoana[Nr_max1];
            using (StreamReader Streader_persoane = new StreamReader(numefisier))
            {
                string liniefisier;
                nr_persoane = 0;
                while ((liniefisier = Streader_persoane.ReadLine()) != null)
                {
                    persoane[nr_persoane++] = new Persoana(liniefisier);
                }
            }
            return persoane;
        }
    }
}
