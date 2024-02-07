using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematik_Oyunu
{

    public class Skorlistesi
    {
        string yol = "skorlistesi.txt";
        StreamWriter _writer;
        StreamReader _reader;
        int enyuksek;
        int enson;
        string gecici;

        public int Enyuksek { get => enyuksek; set => enyuksek = value; }
        public int Enson { get => enson; set => enson = value; }

        public Skorlistesi()
        {
            ensonSkor();
            enyuksekSkor();
        }

        public void skorGir(int skor)
        {
            try
            {  
                _writer = File.AppendText(yol);
                _writer.WriteLine(skor);
                _writer.Close();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Dosyaya yazılamadı.");
            }
        }

        public void ensonSkor()
        {
            _reader = new StreamReader(yol);


            while ((gecici = _reader.ReadLine()) != null)
            {
                    enson = Convert.ToInt16(gecici);
                
            }
            _reader.Close();
        }

        public void enyuksekSkor()
        {
            _reader = new StreamReader(yol);
         

            while ((gecici = _reader.ReadLine()) != null)
            {
                if (Convert.ToInt16(gecici) > enyuksek)
                {
                    enyuksek = Convert.ToInt16(gecici);
                } 
            }
            _reader.Close();
        }

    }
}
