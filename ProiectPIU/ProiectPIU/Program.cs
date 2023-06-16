using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ProiectPIU
{
    class Program
    {
        public static Buget CitiredelaTastatura()
        {
           
            Console.WriteLine("Introduceti bugetul dorit: ");
            float buget = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Intoduceti procentul dorit: ");
            float procent = float.Parse(Console.ReadLine());
            
            Buget bugetnou = new Buget(buget, procent);
            return bugetnou;
        }
        public static Persoana CitiredelaTastatura_persoana()
        {
            Console.WriteLine("Intodu id-ul: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti numele: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele: ");
            string prenume = Console.ReadLine();

            Console.WriteLine("Introduceti varsta: ");
            int varsta = int.Parse(Console.ReadLine());

            Persoana persoana_noua= new Persoana(id, nume, prenume, varsta);
            return persoana_noua;
        }


        static void Main(string[] args)
        {
            
            int nrbugete = 0;
            int nr_persoane = 0;
            int nr_id = 0;
            int Id_persoana = 0;

            //fisier buget
            string numefisier = ConfigurationManager.AppSettings["numefisierBuget"];
            
            Adminbuget fisierbuget = new Adminbuget(numefisier);
            Buget bugetnou = new Buget();
            
            //fisier persoana
            string numefisier_persoana = ConfigurationManager.AppSettings["numefisierPers"];
            AdminPersoane fisier_persoane = new AdminPersoane(numefisier_persoana);
            Persoana persoana_noua = new Persoana();


            
            string optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("C. Citire date Persoana  de la tastatura");
                Console.WriteLine("A. Afisarea suma introdusa");
                Console.WriteLine("F. Afisare date persoana din fisier");
                Console.WriteLine("S. Salvare date  in fisier");
                Console.WriteLine("L. Cautare dupa id");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        persoana_noua = CitiredelaTastatura_persoana();
                        bugetnou = CitiredelaTastatura();
                        Console.ReadKey();
                        break;
                    case "A":
                   
                        Afisare_persoana(persoana_noua);
                        Afisarebuget(bugetnou);
                        Console.ReadKey();

                        break;
                    case "F":
                        Persoana[] sir_persoana = fisier_persoane.Get_Persoana(out nr_persoane);
                        Buget[] bugetesir = fisierbuget.GetBuget(out nrbugete);
                        //Afisare_persoane(sir_persoana, nr_persoane);
                        ///Afisare_bugete(bugetesir, nrbugete);
                        Afisare_date_totale_client(sir_persoana, bugetesir, nr_persoane, nrbugete);
                        Console.ReadKey();

                        break;
                    case "S":
                        
                        Id_persoana = Id_persoana + 1;
                        
                        fisier_persoane.AddPersoana(persoana_noua);
                        nr_persoane = nr_persoane + 1;
                        fisierbuget.AddBuget(bugetnou);
                        nrbugete = nrbugete + 1;
                        nr_id = nr_id + 1;

                        break;
                    case "L":
                        sir_persoana=fisier_persoane.Get_Persoana(out nr_persoane);
                        cautare_client(sir_persoana, nr_persoane);

                        Console.ReadKey();
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
        public static void Afisarebuget(Buget buget)
        {
            string informatii_buget = string.Format("Bugetul este: {0} si procentul este: {1} ", buget.GetBuget().ToString()?? "Necunoscut",
                buget.GetProcent().ToString() ?? "Necunoscut");
            Console.WriteLine(informatii_buget);
        }

        public static void Afisare_persoana(Persoana persoana)
        {
            string informatii_persoana = string.Format("Id-ul este {0}, Numele este: {1} si prenumele este: {2}, iar varsta este:{3} ",
                persoana.GetId().ToString() ?? "Necunoscut",
                persoana.GetNume() ?? "Necunoscut",
                persoana.GetPrenume() ?? "Necunoscut",
                persoana.GetVarsta().ToString() ?? "Necunoscut");
            Console.WriteLine(informatii_persoana);
        }
        public static void Afisare_bugete(Buget[] buget, int nrbugete)
        {
            Console.WriteLine("Bugetele sunt urmatoarele: ");
                for(int i=0;i<nrbugete;i++)
            {
                Afisarebuget(buget[i]);
            }
        }

        public static void Afisare_persoane(Persoana[] persoana, int nr_persoane)
        {
            Console.WriteLine("Persoanele sunt urmatoarele: ");
            for (int i = 0; i < nr_persoane; i++)
            {
                Afisare_persoana(persoana[i]);
            }
        }
        public static void Afisare_date_totale_client(Persoana[] persoana, Buget[] buget,int nr_persoane, int nr_bugete)
        {
            for(int i=0;i<nr_persoane && i<nr_bugete;i++)
            {
                Afisare_persoana(persoana[i]);
                Afisarebuget(buget[i]);
                Console.WriteLine("\n");
            }
        }
        
        public static void cautare_client(Persoana[] persoana, int nr_id)
        {
            Console.WriteLine(nr_id);
            int variabila_cautare=0, ok=0;
            Console.WriteLine("Introduceti id-ul clientului: ");
            variabila_cautare = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < nr_id && ok == 0; i++)
                
            {
                
                if (Convert.ToInt32(persoana[i].GetId()) == variabila_cautare)
                {
                    /*
                    string persoana_potrivita= string.Format("Id - ul este { 0}, Numele este: { 1} si prenumele este: { 2}, iar varsta este: { 3} ",
                    persoana.GetId().ToString() ?? "Necunoscut", persoana.GetNume() ?? "Necunoscut", persoana.GetPrenume() ?? "Necunoscut",
                    persoana.GetVarsta().ToString() ?? "Necunoscut");
                    
                    Console.WriteLine(persoana_potrivita);
                  */
                    Afisare_persoana(persoana[i]);
                    ok = 1;
                }
            }
            if(ok==0)
                {
                    Console.WriteLine("Id-ul nu a fost gasit!");
                }
        }
    }
      
    
}
