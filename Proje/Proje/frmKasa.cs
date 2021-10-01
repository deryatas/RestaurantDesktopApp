using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }
        public static SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=akdeniz;Integrated Security=True");
        private SqlCommand komut;
        private void frmKasa_Load(object sender, EventArgs e)
        {
            masaDurum();
            kayitGetir();
            txtAdet.Text = "0";


        }
        private void masaDurum()
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            masaDurum();
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                string kayit = "insert into masalar (MASANO, DURUM) values(@MASANO, @DURUM) ";
                komut = new SqlCommand(kayit, con);


                komut.Parameters.AddWithValue("@DURUM", textBox2.Text);
                komut.Parameters.AddWithValue("@MASANO", textBox1.Text);


                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("MASA SİPARİŞİ VERİDİ.");
               
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }
        private void kayitGetir()
        {
            con.Open();
            string kayit = "SELECT * from siparis";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, con);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            con.Close();
        }
        

        private void btnArama_Click(object sender, EventArgs e)
        {
            con.Open();

            int srg = int.Parse(textBox4.Text);

            string sorgu = "Select * from siparis where MASANO Like '" + srg + "'";

            SqlDataAdapter adap = new SqlDataAdapter(sorgu, con);

            DataSet ds = new DataSet();

            adap.Fill(ds, "siparis");

            this.dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
        int islem = 0;
        double sayi1 = 0, sayi2 = 0;
        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
                txtAdet.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtAdet.Text == "0")
                txtAdet.Text = "";
            txtAdet.Text += "0";
        }

        private void btnTopla_Click(object sender, EventArgs e)
        {
            islem = 1;
            sayi1 = double.Parse(txtAdet.Text);
            sifirla();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            sayi2 = double.Parse(txtAdet.Text);
            txtAdet.Text = hesapla().ToString("#,#.00");
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {

        }
        public void sifirla()
        {
            txtAdet.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string veri = txtAdet.Text;
            txtAdet.Text = "";
            int i;
            for (i = 0; i < veri.Length - 1; i++)
            {
                txtAdet.Text += veri[i].ToString();
            }
        
    }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("NAKİT ÖDEME SEÇİLİ.");
            }
            else
            {
                MessageBox.Show("SEÇİLİ DEĞİL.");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                MessageBox.Show("KREDİ KART İLE ÖDEME SEÇİLİ.");
            }
            else
            {
                MessageBox.Show("SEÇİLİ DEĞİL.");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                string TARIH = dateTimePicker1.Value.ToString();
                string kayit = "insert into kasa (HESAPNO, TUTAR, TARIH) values( @HESAPNO, @TUTAR,@TARIH) ";
                komut = new SqlCommand(kayit, con);

                komut.Parameters.AddWithValue("@TUTAR", textBox3.Text);
                komut.Parameters.AddWithValue("@HESAPNO", textBox5.Text);
                komut.Parameters.AddWithValue("@TARIH", dateTimePicker1.Text);
                


                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ÖDEME İŞLEMİ GERÇEKLEŞTİ.");
                
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
            con.Open();
            string secmeSorgusu = "SELECT * from siparis where MASANO=@MASANO";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
            secmeKomutu.Parameters.AddWithValue("@MASANO", textBox4.Text);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
            if (dr.Read()) //Datareader herhangi bir okuma yapabiliyorsa aşağıdaki kodlar çalışır.
            {
                string isim = dr["MASANO"].ToString();
                dr.Close();
                //Datareader ile okunan müşteri ad ve soyadını isim değişkenine atadım.
                //Datareader açık olduğu sürece başka bir sorgu çalıştıramayacağımız için dr nesnesini kapatıyoruz.
                DialogResult durum = MessageBox.Show(isim + " Sipariş ödendi masa boşalsın mı?", "Silme Onayı", MessageBoxButtons.YesNo);
                //Kullanıcıya silme onayı penceresi açıp, verdiği cevabı durum değişkenine aktardık.
                if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
                {
                    string silmeSorgusu = "DELETE from siparis where MASANO=@MASANO";
                    //musterino parametresine bağlı olarak ÜRÜN kaydını silen sql sorgusu
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, con);
                    silKomutu.Parameters.AddWithValue("@MASANO", textBox4.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Masa Boşaldı...");
                    //Silme işlemini gerçekleştirdikten sonra kullanıcıya mesaj verdik.
                   
                }
            }
            else
                MessageBox.Show("Urun Bulunamadı.");
            con.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            string secmeSorgusu = "SELECT * from masalar where MASANO=@MASANO";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
            secmeKomutu.Parameters.AddWithValue("@MASANO", textBox4.Text);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
            if (dr.Read()) //Datareader herhangi bir okuma yapabiliyorsa aşağıdaki kodlar çalışır.
            {
                string isim = dr["MASANO"].ToString() ;
                dr.Close();
                //Datareader ile okunan müşteri ad ve soyadını isim değişkenine atadım.
                //Datareader açık olduğu sürece başka bir sorgu çalıştıramayacağımız için dr nesnesini kapatıyoruz.
                DialogResult durum = MessageBox.Show(isim + " Temizlensin mi?", "Silme Onayı", MessageBoxButtons.YesNo);
                //Kullanıcıya silme onayı penceresi açıp, verdiği cevabı durum değişkenine aktardık.
                if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
                {
                    string silmeSorgusu = "DELETE from masalar where MASANO=@MASANO";
                    //musterino parametresine bağlı olarak ÜRÜN kaydını silen sql sorgusu
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, con);
                    silKomutu.Parameters.AddWithValue("@MASANO", textBox4.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Temizlendi...");
                    //Silme işlemini gerçekleştirdikten sonra kullanıcıya mesaj verdik.
                    
                }
            }
            else
                MessageBox.Show("Bulunamadı.");
            con.Close();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKasa menu = new frmKasa();
            menu.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAyarlar menu = new frmAyarlar();
            menu.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public double hesapla()
        {
            double sonuc = 0;

            if (islem == 1)
                sonuc = sayi1 + sayi2;
            else if (islem == 2)
                sonuc = sayi1 - sayi2;
            else if (islem == 3)
                sonuc = sayi1 * sayi2;
            else if (islem == 4)
                sonuc = sayi1 / sayi2;
            else
                sonuc = 0;

            return sonuc;

        }
    }
}
