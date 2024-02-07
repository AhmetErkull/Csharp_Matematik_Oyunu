using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematik_Oyunu
{
    
    public class SoruOlustur
    {
        private string islemtipi; //+
        private int seviye; //2
        private string[] sorular = new string[20];
        private double[] cevaplar = new double[20];
        string islemler = "+-*/";
        Random rand=new Random();
        private static SoruOlustur soruOlustur;
        bool rgtik = false;

        public string[] getSorular { get => sorular;}
        public double[] getCevaplar { get => cevaplar;}
        public string setIslemtipi { set => islemtipi = value; }
        public int Seviye { set => seviye = value; get => seviye; }



        //singleton bir const üretildi 
        private SoruOlustur() { }

        public static SoruOlustur NesneTuret()
        {
            if (soruOlustur == null)
            {
                soruOlustur = new SoruOlustur();
            }
            return soruOlustur;
        }
 

        public void Yarat() // cevapları ve soruları oluşturma
        {
            double s1=0, s2=0;
            int maxdeger,mindeger;



            /*
                 seviye 1 = 1-1 (basamak) /10
                 seviye 2 = 1-2 /100
                 seviye 3 = 1-3 /1000
                 seviye 4 = 2-2 /10000
                 seviye 5 = 2-3 100/100
            */


            mindeger = (int)Math.Pow(10, seviye-1); //100
            maxdeger = (int)Math.Pow(10, seviye);  //1000

            //işlem tipi rastgeleyse işlem rastgele atanıyor

            if (islemtipi == "r")
            {
                rgtik = true;


            }
          


            for (int i = 0; i < 20; i++)
            {
                if (rgtik)
                {
                    islemtipi = islemler[rand.Next(0, 4)].ToString();
                }
                //seviyeye göre sayılar atanıyor

                if (seviye==4)
                {
                    s1 = rand.Next(10, 100);
                    s2 = rand.Next(10, 100);

                    if (islemtipi == "/")
                    {
                        do
                        {
                            s1 = rand.Next(10, 100);
                            s2 = rand.Next(10, 100);
                        } while (s1 % s2 != 0 || s1 == s2);

                        if (islemtipi == "-")
                        {
                            while (s1 <= s2)
                            {
                                s1 = rand.Next(10, 100);
                                s2 = rand.Next(10, 100);
                            }
                        }

                    }
                }
                else if(seviye==5)
                {
                    s2 = rand.Next(10, 100); 
                    s1 = rand.Next(100, 1000);

                    if (islemtipi == "/")
                    {
                        do
                        {
                            s1 = rand.Next(100, 1000);
                            s2 = rand.Next(10, 100);
                        } while (s1 % s2 != 0||s1==s2);

                    }
                }
                else
                {
                    s1 = rand.Next(mindeger, maxdeger); //4
                    s2 = rand.Next(1, 10); //1
                    if (islemtipi == "/")
                    {
                        do
                        {
                            s1 = rand.Next(mindeger, maxdeger);
                            s2 = rand.Next(2, 10);

                        } while (s1 % s2 != 0 || s1 == s2);
                    }
                    if (islemtipi == "-")
                    {
                        while (s1 <= s2)
                        {
                            s1 = rand.Next(mindeger, maxdeger);
                            s2 = rand.Next(1, 10);
                        }
                    }
                }

            
                //sorular ayarlanıyor
                sorular[i] = s1 + " " + islemtipi + " " + s2 + " = ";

                //cevaplar ayarlanıyor
                switch (islemtipi)
                {
                    case "+":
                        cevaplar[i] = s1 + s2;
                        break;
                    case "-":
                        cevaplar[i] = s1 - s2;
                        break;
                    case "*":
                        cevaplar[i] = s1 * s2;
                        break;
                    case "/":
                        cevaplar[i] = s1 / s2;
                        break;
                    default:
                        break;
                }
            }

          

        }
    }
}
