using System;
using System.Windows.Forms;
using System.IO;

namespace MetniTerstenYazdir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Metnin ters halini diğer MetinTers çevir textbox ına yazdırır.
        {
            richTextBox2.Text = "";
            char[] dizi = richTextBox1.Text.ToCharArray();
            for (int i = dizi.Length - 1; i >= 0; i--)
            {
                richTextBox2.Text += dizi[i];
            }
        }

        private void button2_Click(object sender, EventArgs e) //Metinleri temizler.
        {
            richTextBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) // seçilen zengin metin belgesini yazdırır ve ters çevirir.
        {

            openFileDialog1.Filter = "Tüm dosyalar(.*)|*.*| Zengin Metin Belgesi(*.rtf)|*.rtf";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                if (Path.GetExtension(filePath) == ".rtf")
                {
                    StreamReader rd = new StreamReader(filePath);
                    richTextBox1.Rtf = rd.ReadToEnd();
                    button1_Click(null, null);
                    rd.Close();
                }

                else
                {
                    MessageBox.Show("Dosya uzantısı .rtf olmalıdır.");
                }
            }
        }
    }
}
