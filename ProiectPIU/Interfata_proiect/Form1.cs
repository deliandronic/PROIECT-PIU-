using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;

namespace Interfata_proiect
{
    public partial class Form1 : Form
    {
        ProiectPIU.AdminPersoane admin_pers;
        ProiectPIU.Adminbuget admin_buget;
        Font medium = new Font("Times New Roman", 14);
        Font standard = new Font("Times New Roman", 12);

        public Form1()
        {
            
            //configurare acces fisier text persoane
            
            string numefisier = ConfigurationManager.AppSettings["numefisierPers"];
            string locatiefisier_solutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string cale_completa_fisier = locatiefisier_solutie + "\\" + numefisier;
            admin_pers = new ProiectPIU.AdminPersoane(cale_completa_fisier);

            //---------------------

            //configurare acces fisier text pbugete

            string numefisier_buget = ConfigurationManager.AppSettings["numefisierBuget"];
            string locatiefisier_solutie_buget = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string cale_completa_fisier_buget = locatiefisier_solutie_buget + "\\" + numefisier_buget;
            admin_buget = new ProiectPIU.Adminbuget(cale_completa_fisier_buget);

            
            InitializeComponent();

            //creare butoane active
            
            button1.MouseEnter += OnMouseEnterButton1;
            button1.MouseLeave += OnMouseLeaveButton1;

            button2.MouseEnter += OnMouseEnterButton2;
            button2.MouseLeave += OnMouseLeaveButton2;

            //creare label uri active

            label7.MouseEnter +=OnMouseEnterLabel7;
            label7.MouseLeave += OnMouseLeaveLabel7;

            label8.MouseEnter += OnMouseEnterLabel8;
            label8.MouseLeave += OnMouseLeaveLabel8;

            label9.MouseEnter += OnMouseEnterLabel9;
            label9.MouseLeave += OnMouseLeaveLabel9;

            label10.MouseEnter += OnMouseEnterLabel10;
            label10.MouseLeave += OnMouseLeaveLabel10;
            
            label11.MouseEnter += OnMouseEnterLabel11;
            label11.MouseLeave += OnMouseLeaveLabel11;

            label12.MouseEnter += OnMouseEnterLabel12;
            label12.MouseLeave += OnMouseLeaveLabel12;

            label13.MouseEnter += OnMouseEnterLabel13;
            label13.MouseLeave += OnMouseLeaveLabel13;

        }

        //resetare date
        private void Resetare_date()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
        }

        //--------------------------------------------------------------
        private void OnMouseEnterLabel7(object sender, EventArgs e)
        {
            label7.ForeColor = Color.CadetBlue;
            label7.Font=medium;

        }

        
        private void OnMouseLeaveLabel7(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Blue;
            label7.Font = standard;
        }
        //--------------------------------------------------------------
        private void OnMouseEnterLabel8(object sender, EventArgs e)
        {
            label8.ForeColor = Color.DarkTurquoise;
            label8.Font = medium;
        }


        private void OnMouseLeaveLabel8(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Blue;
            label8.Font = standard;
        }
        //--------------------------------------------------------------
        private void OnMouseEnterLabel9(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Black;
            label9.Font = medium;
        }


        private void OnMouseLeaveLabel9(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Blue;
            label9.Font = standard;
        }
        //--------------------------------------------------------------
        private void OnMouseEnterLabel10(object sender, EventArgs e)
        {
            label10.ForeColor = Color.BlueViolet;
            label10.Font = medium;
        }


        private void OnMouseLeaveLabel10(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Blue;
            label10.Font = standard;
        }
        //--------------------------------------------------------------
        private void OnMouseEnterLabel11(object sender, EventArgs e)
        {
            label11.ForeColor = Color.CornflowerBlue;
            label11.Font = medium;
        }


        private void OnMouseLeaveLabel11(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Blue;
            label7.Font = standard;
        }
        //--------------------------------------------------------------
        private void OnMouseEnterLabel12(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Crimson;
            label12.Font = medium;
        }


        private void OnMouseLeaveLabel12(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Blue;
            label12.Font = standard;
        }
        //--------------------------------------------------------------
        private void OnMouseEnterLabel13(object sender, EventArgs e)
        {
            label13.ForeColor = Color.DarkSeaGreen;
            label13.Font = medium;
        }


        private void OnMouseLeaveLabel13(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Blue;
            label13.Font = standard;
        }
        //---------------------------------------------------------

        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;

        }


        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            
        }

        //----------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==String.Empty || textBox2.Text==String.Empty || textBox3.Text==String.Empty || textBox4.Text==String.Empty || textBox5.Text==String.Empty || textBox6.Text==String.Empty )
            {
                label21.Text = "Nu ai introdus date";
                return;
            }
            else { 
            ProiectPIU.Persoana pers = new ProiectPIU.Persoana(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text));
            admin_pers.AddPersoana(pers);
            ProiectPIU.Buget buget = new ProiectPIU.Buget(float.Parse(textBox5.Text), float.Parse(textBox6.Text));
            admin_buget.AddBuget(buget);
            }
            label21.Text = String.Empty;
            Resetare_date();
            
            
        }
        private void OnMouseEnterButton2(object sender, EventArgs e)
        {
            button2.BackColor = Color.Blue;

        }
        private void OnMouseLeaveButton2(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            afisare_persoane();
        }
        private void afisare_persoane()
        {
            ArrayList date_persoane = admin_pers.Get_persoane();
            ArrayList date_bugete = admin_buget.Get_bugete();
            int nr_bugete = date_bugete.Count;
            int nr_persoane = date_persoane.Count;
            
            
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
            label20.Text = "";
            foreach (ProiectPIU.Persoana persoana in date_persoane)
            {
                
                label15.Text +=Convert.ToString( persoana.GetId())+"\n";
                Controls.Add(label15);

                label16.Text += persoana.GetNume()+ "\n";
                Controls.Add(label16);

                label17.Text += persoana.GetPrenume()+ "\n";
                Controls.Add(label17);

                label18.Text += Convert.ToString(persoana.GetVarsta())+"\n";
                Controls.Add(label18);


            }
            
            foreach(ProiectPIU.Buget buget in date_bugete)
            {
               
                label19.Text += Convert.ToString(buget.GetBuget())+ "\n";
                Controls.Add(label19);

                label20.Text += Convert.ToString(buget.GetProcent())+ "\n";
                Controls.Add(label20);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
