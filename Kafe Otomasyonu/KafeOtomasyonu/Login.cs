using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Sql;
namespace KafeOtomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        SqlDataReader dr;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-99QH58A\\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True;");
        public void verilerimigöster(string veriler)
        {

         

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM k_giris where kullanici_adi=@user AND kullanici_sifre=@pass";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-99QH58A\\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True;");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(textBox1.Text + " " + "Başarılı bir şekilde giriş yaptınız.");
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rezerve rezerve = new rezerve();
            rezerve.Show();

        }
    }
}
