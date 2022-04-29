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
using System.IO;

namespace KafeOtomasyonu
{
    /* Lütfen İzinsiz Paylaşımda Bulunmayınız! 
                     ÖMER FARUK KARACAN            */
    public partial class masa_bilgi : Form
    {

        public string yazi;
        int masa_numara;
        public string filtres;
        string masa_adi;
        public string masa_deger;
        int sifir = 0;
        public masa_bilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-99QH58A\\SQLEXPRESS;Initial Catalog=kafe;Integrated Security=True;");
        DataTable table = new DataTable();
        void product_view()
        {
            baglanti.Open();
            string kayit = "SELECT * from product_add where product_category LIKE '"+filtres+"%'";
            SqlCommand komut = new SqlCommand(kayit, baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView2.DataSource = dt;
            this.dataGridView2.Columns[6].Visible = false;
            this.dataGridView2.Columns[0].Visible = false;
            baglanti.Close();
        }
        void masa_listle()
        {
            masa_degeri_getir();
            baglanti.Open();
            string kayit = "SELECT * from masa_urunler where masa_adi LIKE '" + masa_adi + "%' AND masa_deger LIKE '" + masa_deger + "%' ";
            SqlCommand komut = new SqlCommand(kayit, baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[7].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
            this.dataGridView1.Columns[0].Visible = false;
            baglanti.Close();
        }
       
        private void masa_bilgi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = table;
            product_view();
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            label2.Text = yazi;
            masa_degeri_getir();
            masa_numara = int.Parse(yazi); masa_adi = "masa_" + masa_numara;
            label15.Text = DateTime.Now.ToShortDateString();
            textBox1.Text = "0";
        }

        void tutar_sıfırla()
        {
            label6.Text = "0";
            label7.Text = "0";
            label8.Text = "0";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            tutar_sıfırla();
            masa_listle();
                
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        void masa_degeri_getir()
        {
            baglanti.Open(); 
            string masa_degercon = "SELECT * from masa_deger where id LIKE '" + masa_numara + "%'";
            SqlCommand deger_komut = new SqlCommand(masa_degercon, baglanti);
            SqlDataReader dr = deger_komut.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                masa_deger = dr.GetValue(1).ToString();
            }
            dr.Close();
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tutar_sıfırla();

            string product_name = label9.Text.Trim();
            string product_category = label14.Text.Trim();
            string product_price = label16.Text.Trim();
            string prooduct_adet = textBox1.Text.Trim();
            string product_image = pictureBox1.ImageLocation;
            
           
             
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                masa_numara = int.Parse(yazi);
                string kayit = "insert into masa_urunler(masa_adi,product_name,product_category,masa_deger,product_adet,product_price,product_image,tarih) values (@masa_adim,@product_name,@product_category,@masa_deger,@product_adet,@product_price,@product_image,@tarih)";
                string masa_degercon = "SELECT * from masa_deger where id LIKE '" + masa_numara + "%'";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                SqlCommand deger_komut = new SqlCommand(masa_degercon, baglanti);
                SqlDataReader dr = deger_komut.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    masa_deger = dr.GetValue(1).ToString();
                }
                if (int.Parse(textBox1.Text) > 0)
                {
                    string masa_adı = "masa" + label2.Text;
                    komut.Parameters.AddWithValue("@masa_adim", masa_adi);
                    komut.Parameters.AddWithValue("@product_name", product_name);
                    komut.Parameters.AddWithValue("@product_category", product_category);
                    komut.Parameters.AddWithValue("@masa_deger", masa_deger);
                    komut.Parameters.AddWithValue("@product_adet", textBox1.Text);
                    komut.Parameters.AddWithValue("@product_price", int.Parse(label16.Text));
                    komut.Parameters.AddWithValue("@product_image", product_image);
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString());

                    dr.Close();
                    deger_komut.ExecuteNonQuery();
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ürün Yüklendi.");
                }
                else
                {
                    MessageBox.Show("Lütfen ürün seçiniz veya adet giriniz!");
                }

                textBox1.Text = "0";
                
                
                
                baglanti.Close();


            }
            catch (Exception hata)
            {
                product_view();
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tutar_sıfırla();
            baglanti.Open();
            DataGridViewRow row = dataGridView1.CurrentRow;
            int idlik = int.Parse(row.Cells[0].Value.ToString());
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            
            string masa_sil= "DELETE  masa_urunler where id LIKE '" + idlik + "%'";
            SqlCommand deger_sil = new SqlCommand(masa_sil, baglanti);
            deger_sil.ExecuteNonQuery();
            baglanti.Close();
            masa_listle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float kdv;
            int toplam = 0;
            if (dataGridView1.Visible==true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                }
                label6.Text = toplam.ToString() + "  " + "TL";
                kdv = (toplam * 18) / 100;
                if (toplam > 0)
                {

                    label7.Text = kdv.ToString() + "  " + "TL";
                }
                else
                {
                    MessageBox.Show("Hata oluştu lütfen siparişler bölümünü seçiniz!");
                }
                float sonuc = kdv + toplam;

                label8.Text = sonuc.ToString();
            }
            else
            {
                MessageBox.Show("Hata oluştu lütfen siparişler bölümünü seçiniz!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(label8.Text) > 0)
            {

            
            try
            {
                masa_degeri_getir();
                baglanti.Open();
                    string kayits = "insert into masa_tutar(masa_adi,masa_deger,masa_tutar) values (@tcno,@isim,@soyisim)";

                    SqlCommand komut = new SqlCommand(kayits, baglanti);

                    komut.Parameters.AddWithValue("@tcno", masa_adi);
                    komut.Parameters.AddWithValue("@isim", masa_deger);
                    komut.Parameters.AddWithValue("@soyisim", int.Parse(label8.Text));
                    
                    

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    

                    masa_degeri_getir();
                baglanti.Open();

                int masa_degeri = int.Parse(masa_deger);
                masa_degeri = masa_degeri + 1;
                string deger_mas = Convert.ToString(masa_degeri);
                string guncel = "Update masa_deger set masa_deger=@masa_degeri Where masa_adi ='"+masa_adi+ "'";
                SqlCommand guncelle = new SqlCommand(guncel, baglanti);
                guncelle.Parameters.AddWithValue("@masa_adi", masa_adi);
                guncelle.Parameters.AddWithValue("@masa_degeri", deger_mas);

                guncelle.ExecuteNonQuery();
                baglanti.Close();

                    MessageBox.Show("Masa Temizlendi.");
                label6.Text = "0";
                label7.Text = "0";
                label8.Text = "0";
                    baglanti.Open();
                    string sql = "Update masa_durum set masa_durum=@masa_durum Where masa_adi ='" + masa_adi + "'";
                    SqlCommand cmd = new SqlCommand(sql, baglanti);
                    cmd.Parameters.AddWithValue("@masa_durum", sifir);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    this.Hide();
                    
            }
            catch (Exception hata)
            {

               MessageBox.Show("İşlem gerçekleştirilemedi"+hata.Message);
            }
            }
            else
            {
                MessageBox.Show("Lütfen ilk önce tutarı hesaplatınız!");
            }



        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            filtres = "Yemek";
            product_view();
        }

      
        private void button7_Click(object sender, EventArgs e)
        {
            filtres = "Tatlılar";
            product_view();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            filtres = "Sıcak İçicekler";
            product_view();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            filtres = "Soğuk İçicekler";
            product_view();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
           


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tutar_sıfırla();
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            filtres = "";
            product_view();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow rows = dataGridView1.CurrentRow;
            pictureBox1.ImageLocation = rows.Cells[7].Value.ToString();
            label9.Text = rows.Cells[1].Value.ToString();
            label14.Text = rows.Cells[2].Value.ToString();
            label16.Text = rows.Cells[3].Value.ToString();
            
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.CurrentRow;
            pictureBox1.ImageLocation = row.Cells[6].Value.ToString();
            label9.Text = row.Cells[1].Value.ToString();
            label14.Text = row.Cells[2].Value.ToString();
            label16.Text = row.Cells[3].Value.ToString();
            
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
            int text = int.Parse(textBox1.Text) +1 ;
            textBox1.Text = text.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) > 0)
            {
                int text = int.Parse(textBox1.Text) - 1;
                textBox1.Text = text.ToString();
            }
            else
            {
                MessageBox.Show("Ürün adeti SIFIR'dan küçük olamaz!");
            }
           
        }
    }
}
/* Lütfen İzinsiz Paylaşımda Bulunmayınız! 
                    ÖMER FARUK KARACAN            */