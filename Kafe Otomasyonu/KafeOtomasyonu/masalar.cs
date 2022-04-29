using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KafeOtomasyonu
{
    public partial class masalar : Form
    {
        public string yazi;
        public masalar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "1";
            masa.Show();
        }

        private void masalar_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "2";
            masa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "3";
            masa.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "4";
            masa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "5";
            masa.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "6";
            masa.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "7";
            masa.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "8";
            masa.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "9";
            masa.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "10";
            masa.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "11";
            masa.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            masa_bilgi masa = new masa_bilgi();
            masa.yazi = "12";
            masa.Show();
        }
    }
}
