using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matematik_Oyunu
{
    public partial class Baslangic_Ekranı : Form
    {
        SoruOlustur soruOlustur = SoruOlustur.NesneTuret();
        SeviyeKontrol seviyeKontrol = new SeviyeKontrol();
        public Baslangic_Ekranı()
        {
            InitializeComponent();

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void seviyelereGec()
        {
            Seviyeler seviyeler = new Seviyeler();
            seviyeler.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            soruOlustur.setIslemtipi = "+";
            seviyelereGec();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            soruOlustur.setIslemtipi = "-";
            seviyelereGec();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            soruOlustur.setIslemtipi = "*";
            seviyelereGec();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            soruOlustur.setIslemtipi = "/";
            seviyelereGec();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            soruOlustur.setIslemtipi = "r";
            seviyelereGec();
        }

        private void Baslangic_Ekranı_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 3 && args[1].ToLower() == "open")
            {
                int level = Convert.ToInt16(args[2]);

                seviyeKontrol.seviyeAyarla(level-1, '1');

            }
           
        }
    }
}
