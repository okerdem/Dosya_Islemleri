using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dosya_İslemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string sDosyaAdi, sDosyaYolu;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonYolSec_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sDosyaYolu = folderBrowserDialog1.SelectedPath.ToString();
                textBox2.Text = sDosyaYolu;
            }
        }

        private void buttonOku_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                for (string sSatir=sr.ReadLine() ; sSatir != null;sSatir=sr.ReadLine())
                {
                    listBox1.Items.Add(sSatir);
                }
                sr.Close();
            }
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter="Metin Dosyaları|*.txt";
            saveFileDialog1.Title = "Metni Kaydet";
            saveFileDialog1.ShowDialog();
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
        }

        private void buttonTemizle2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonOlustur_Click(object sender, EventArgs e)
        {
            sDosyaAdi = textBox1.Text;
            StreamWriter sw = File.CreateText(sDosyaYolu + "\\" + sDosyaAdi + ".txt");
            sw.Close();
        }
    }
}
