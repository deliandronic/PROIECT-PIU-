using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPIU
{
    public class Buget
    {
        double buget;
        double procent;
        private const char separator = ',';
        private const int BUGET=0;
        private const int PROCENT=1;

        public Buget()
        {
            buget = 0.0f;
            procent = 0.0f;
        }
        public Buget(double _buget, double _procent)
        {
            buget = _buget;
            procent = _procent;
        }


        public string Info()
        {
            
            return $"Buget:{buget}, procent:{procent}";

        }
        public double GetBuget()
        {
            return buget;
        }
        public double GetProcent()
        {
            return procent;
        }

        public string conversielasirptfisier()
        {
            string obiectptsir = string.Format("{1}{0}{2}{0}", separator, buget.ToString(), procent.ToString());
            return obiectptsir;
        }

        public Buget(string liniefisier)
        {
            var datefisier = liniefisier.Split(separator);
            buget = float.Parse(datefisier[BUGET]);
            procent = float.Parse(datefisier[PROCENT]);
        }
        
    }
}
