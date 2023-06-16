using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPIU
{
    public class Persoana
    {
        string Nume;
        string Prenume;
        int Varsta;
        int Idpersoana;
        private const char separator_sec= ',';
        private const int IDPERS = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int VARSTA = 3;

        public Persoana()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            Varsta = 0;
            Idpersoana = 0;

        }

        public Persoana( int _id, string _nume, string _prenume, int _varsta)
        {
            Idpersoana = _id;
            Nume = _nume;
            Prenume = _prenume;
            Varsta = _varsta;

        }
        public string Info_persoana()
        {
            return $"Id: {Idpersoana}, Nume: {Nume}, prenume: {Prenume}, varsta: {Varsta}";

        }
        public string GetNume()
        {
            return Nume;
        }
        public string GetPrenume()
        {
            return Prenume;
        }
        public int GetVarsta()
        {
            return Varsta;
        }
        public int GetId()
        {
            return Idpersoana;
        }
        public string conversie_la_sir_pentru_fisier()
        {
            string obiect_pt_sir = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}", separator_sec,Idpersoana.ToString()??"Necunoscut",
                Nume??"Necunoscut", Prenume??"Necunoscut", Varsta.ToString()??"Necunoscut");
            return obiect_pt_sir;
        }
        public Persoana(string linie_fisier)
        {
            string [] datefisier_pers = linie_fisier.Split(separator_sec);
            Idpersoana =Convert.ToInt32( datefisier_pers[IDPERS]);
            Nume = datefisier_pers[NUME];
            Prenume = datefisier_pers[PRENUME];
            Varsta =Convert.ToInt32( datefisier_pers[VARSTA]);
        }
    }

}
