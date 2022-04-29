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
    /* Lütfen İzinsiz Paylaşımda Bulunmayınız! 
                    ÖMER FARUK KARACAN            */
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productadd productadd = new productadd();
            productadd.MdiParent = this;
            productadd.Show(); 
            panel1.Controls.Clear(); 

            productadd.TopLevel = false;
            panel1.Controls.Add(productadd); 

            productadd.Show(); 
            productadd.Dock = DockStyle.Fill;
            productadd.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            masalar masalar = new masalar();
            masalar.MdiParent = this;
            masalar.Show();
            panel1.Controls.Clear();

            masalar.TopLevel = false;
            panel1.Controls.Add(masalar);

            masalar.Show();
            masalar.Dock = DockStyle.Fill;
            masalar.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rezerve masalar = new rezerve();
            masalar.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satışlar masalar = new satışlar();
            masalar.MdiParent = this;
            masalar.Show();
            panel1.Controls.Clear();

            masalar.TopLevel = false;
            panel1.Controls.Add(masalar);

            masalar.Show();
            masalar.Dock = DockStyle.Fill;
            masalar.BringToFront();
        }
    }
}
/* Lütfen İzinsiz Paylaşımda Bulunmayınız! 
                    ÖMER FARUK KARACAN            */