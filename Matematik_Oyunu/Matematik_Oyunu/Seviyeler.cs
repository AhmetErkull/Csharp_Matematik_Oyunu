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
    public partial class Seviyeler : Form
    {
        SoruOlustur soruOlustur = SoruOlustur.NesneTuret();
        SeviyeKontrol seviyeKontrol = new SeviyeKontrol();

        void sorularaGec()
        {
            Sorular sorular = new Sorular();
            sorular.Show();
            this.Hide();
            
        }
        void geriGit()
        {
            Baslangic_Ekranı baslangic_Ekranı = new Baslangic_Ekranı();
            baslangic_Ekranı.Show();
            this.Close();
        }

        public Seviyeler()
        {
            InitializeComponent();
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            geriGit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button buton= (Button)sender;
            soruOlustur.Seviye=Convert.ToInt16(buton.Text.Substring(7,1));
            sorularaGec();
            
        }

        private void Seviyeler_Load(object sender, EventArgs e)
        {
            button1.Enabled = seviyeKontrol[0];
            button2.Enabled = seviyeKontrol[1];
            button3.Enabled = seviyeKontrol[2];
            button4.Enabled = seviyeKontrol[3];
            button5.Enabled = seviyeKontrol[4];

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button && control.Enabled == false)
                {
                    control.Text += " (Kilitli)";
                }
                else if(control is Button && control.Enabled == true)
                {
                    control.Font = new Font(control.Font.FontFamily, 30, control.Font.Style);
                }
            }


        }
    }
}
