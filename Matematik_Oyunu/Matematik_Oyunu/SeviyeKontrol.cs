using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Matematik_Oyunu
{
    public class SeviyeKontrol
    {


        string yol = "seviyeler.txt";
        private bool[] levels = new bool[5];
        string metin;

        public SeviyeKontrol()
        {
            if (File.Exists(yol))
            {
                 metin = File.ReadAllText(yol);
            }

            for (int i = 0; i < 5; i++)
            {
                if (metin[i] == '1')
                {
                    levels[i] = true;
                }
                else
                {
                    levels[i] = false;
                }
            }


        }

        public void seviyeAyarla(int level,char deger)
        {

            char[] karakterDizisi = metin.ToCharArray();
            karakterDizisi[level] = deger;
            metin = new string(karakterDizisi);
            File.WriteAllText(yol, metin);
        }
            
        

        
        public bool this[int i]
        {
            get {

                    return levels[i];

            }
            set
            {
                levels[i] = value;
            }
        }
    }
}
