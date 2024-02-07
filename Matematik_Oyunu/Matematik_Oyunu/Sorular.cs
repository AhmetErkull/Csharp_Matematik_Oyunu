using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Matematik_Oyunu.Skorlistesi;

namespace Matematik_Oyunu
{
    public partial class Sorular : Form
    {
        SoruOlustur soruOlustur = SoruOlustur.NesneTuret();
        Skorlistesi skr = new Skorlistesi();
        int hangiblok = 0;
        int dogru=0, yanlis=0;
        int sure;
        string yildiz;
        private int passayisi = 0;
        ArrayList paslar = new ArrayList();
        ArrayList pascevaplar = new ArrayList();
        byte pashakki = 0;
        int gecicipassayaci = 0;


        bool pasbloku = false;

        public Sorular()
        {
            InitializeComponent();
        }

    
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Sorular_Load(object sender, EventArgs e)
        {
            label6.Text = "En yüksek skor:" + skr.Enyuksek + "\n\n\nSon skor:" +skr.Enson;
            soruOlustur.Yarat();
            sorulariAta();
            sure = soruOlustur.Seviye*50;
            lblsure.Text = sure.ToString();
            timer1.Start();
            
        }

        private void dogrusayisiKontrol()
        {
            if (dogru>10)
            {
                if (dogru>=11&&dogru<=15)
                {
                    yildiz = "⭐";
                }
                else if (dogru >= 16 && dogru <= 18)
                {
                    yildiz = "⭐⭐";
                }
                else if (dogru >= 19 && dogru <= 20)
                {
                    yildiz="⭐⭐⭐";
                }
                MessageBox.Show(yildiz.ToString()+" yıldız aldınız.");
                MessageBox.Show("Puanınız : "+skorHesapla());
                if (soruOlustur.Seviye != 5)
                {
                    SeviyeKontrol seviyeKontrol = new SeviyeKontrol();
                    seviyeKontrol.seviyeAyarla(soruOlustur.Seviye, '1');
                    MessageBox.Show("Yeni seviyenin kilidi açıldı.");
                }
                else
                {
                    MessageBox.Show("Bütün seviyeleri geçtiniz. Tebrikler...");
                }
            }
            else
            {
                MessageBox.Show("Diğer seviyeye geçemediniz.");
            }
        }

        int skorHesapla()
        {
            return dogru * 5*(soruOlustur.Seviye+2) - yanlis * 2 *(soruOlustur.Seviye + 1) + passayisi;
        }

        private void sorulariAta()
        {
            if (hangiblok == 20||(gecicipassayaci==passayisi&&pasbloku))
            {
                if (passayisi == 0||pashakki==2)
                {
                    dogrusayisiKontrol();
                    skr.skorGir(skorHesapla());
                    Seviyeler seviye = new Seviyeler();
                    seviye.Show();
                    this.Close();
                    return;
                }
                else
                {
                    pashakki++;
                    hangiblok = 0;
                    paslariAktar();
                    pasbloku = true;
                    
                    return;

                }
            }
            else if (pasbloku)
            {
                    paslariAktar();
                    return;
            }
            sorulariAktar();
       
        }

        void paslariAktar()
        {
            labeltemizle();
            Label[] lbler = { label1, label2, label3, label4, label5 };
           // MessageBox.Show(passayisi.ToString());
            
            for (int i = 0; i < 5; i++)
            {
             //   MessageBox.Show((i + hangiblok).ToString());
                if (i + hangiblok<passayisi)
                {
                    lbler[i].Text = paslar[i + hangiblok].ToString();
                }
                
            }
            /*label1.Text = paslar[0 + hangiblok].ToString();
            label2.Text = paslar[1 + hangiblok].ToString();
            label3.Text = paslar[2 + hangiblok].ToString();
            label4.Text = paslar[3 + hangiblok].ToString();
            label5.Text = paslar[4 + hangiblok].ToString();*/

        }
        void sorulariAktar()
        {
            labeltemizle();

            label1.Text = soruOlustur.getSorular[0 + hangiblok];
            label2.Text = soruOlustur.getSorular[1 + hangiblok];
            label3.Text = soruOlustur.getSorular[2 + hangiblok];
            label4.Text = soruOlustur.getSorular[3 + hangiblok];
            label5.Text = soruOlustur.getSorular[4 + hangiblok];
        }


        void pasKontrol()
        {
            foreach (Control item in tableLayoutPanel1.Controls)
            {
                if (item is TextBox&&(item.Text==""||item.Text==null||item.Text==" ")&&!pasbloku)
                {

                    paslar.Add(soruOlustur.getSorular[(item.TabIndex-1) + hangiblok]);
                    pascevaplar.Add(soruOlustur.getCevaplar[(item.TabIndex - 1) + hangiblok]);
                    passayisi++;
                    
                }
            }
        }
        void labeltemizle()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            pasKontrol();

            TextBox[] textBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5 };
            if (!pasbloku)
            {
                
                for (int i = 0; i < 5; i++)
                {
                    if (!string.IsNullOrWhiteSpace(textBoxes[i].Text))
                    {
                        if (textBoxes[i].Text == soruOlustur.getCevaplar[i + hangiblok].ToString())
                        {
                            dogru++;
                        }
                        else
                        {
                            yanlis++;
                        }
                    }
                  
                }
                
            }
            else
            {

                for (int i = 0; i < 5; i++)
                {

                    if (i + hangiblok < passayisi)
                        {
                        if (!string.IsNullOrWhiteSpace(textBoxes[i].Text))
                        {
                            if (textBoxes[i].Text == pascevaplar[i + hangiblok].ToString())
                            {
                                dogru++;
                            }
                            else
                            {
                                yanlis++;
                            }

                            paslar.RemoveAt(i + hangiblok);
                            pascevaplar.RemoveAt(i + hangiblok);
                            passayisi--;
                            hangiblok--;
                        }

                       

                        gecicipassayaci = i + hangiblok + 1;
                        }
                    

                }

            }
         



            hangiblok += 5;

            sorulariAta();

            tboxVisible();
            temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("doğru: "+dogru.ToString()+" yanlış:"+yanlis.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblsure.Text = sure.ToString();
            
            if (sure==0)
            {
                timer1.Stop();
                MessageBox.Show("süre bitti");
                dogrusayisiKontrol();
                Seviyeler seviye = new Seviyeler();
                seviye.Show();
                this.Close();

            }
            sure--;  
        }

        void tboxVisible()
        {
            TextBox[] textBoxes = { textBox1, textBox2, textBox3, textBox4, textBox5 };

            foreach (TextBox item in textBoxes)
            {
                item.Visible = true;
            }

            Label[] lbler = { label1, label2, label3, label4, label5 };

            for (int i = 0; i < 5; i++)
            {
                if (string.IsNullOrWhiteSpace(lbler[i].Text))
                {
                    textBoxes[i].Visible = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
