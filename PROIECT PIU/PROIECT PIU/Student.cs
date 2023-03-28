using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT_PIU
{
    public class Student
    {
        private const char Separator_Date = ',';

        public string nume_student;
        public string prenume_student;
        public string pozitie; //Senat sau Consiliul Facultatii
        public string facultate;

        public Student()
        {
            nume_student = prenume_student = pozitie = facultate = string.Empty;
        }

        public Student (string Nume_Stud, string Prenume_Stud , string Poz, string Fac)
        {
            this.nume_student = Nume_Stud;
            this.prenume_student = Prenume_Stud;
            this.pozitie = Poz;
            this.facultate = Fac;
        }
        public Student(string linieFisier)
        {
            var dateFisier = linieFisier.Split(Separator_Date);

            nume_student = dateFisier[0];
            prenume_student = dateFisier[1];
            pozitie = dateFisier[2];
            facultate = dateFisier[3];
        }

        public string ConversieLaSir_PentruFisier()
        {
            string StudPtFis= string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                Separator_Date,
                nume_student,
                prenume_student,
                pozitie,
                facultate);

            return StudPtFis;
        }


        public string Get_nume_student()
        {
            return nume_student;
        }

        public string Get_prenume_student()
        {
            return prenume_student;
        }

        public string Get_pozitie()
        {
            return pozitie;
        }
        public string Get_facultate()
        {
            return facultate;
        }

    }
}
