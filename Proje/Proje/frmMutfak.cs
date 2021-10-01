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
    public partial class frmMutfak : Form
    {
        public frmMutfak()
        {
            InitializeComponent();
        }
        static string conString = ("Data Source=localhost;Initial Catalog=akdeniz;Integrated Security=True");
        SqlConnection baglanti = new SqlConnection(conString);
        private SqlCommand komut;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from urunler ";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            baglanti.Close();
        }

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            kayitGetir();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAyarlar menu = new frmAyarlar();
            menu.Show();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from urunler where URUNAD=@URUNAD";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@URUNAD", textBox4.Text);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
            if (dr.Read()) //Datareader herhangi bir okuma yapabiliyorsa aşağıdaki kodlar çalışır.
            {
                string isim = dr["URUNAD"].ToString() + " " + dr["FIYAT"].ToString();
                dr.Close();
                //Datareader ile okunan müşteri ad ve soyadını isim değişkenine atadım.
                //Datareader açık olduğu sürece başka bir sorgu çalıştıramayacağımız için dr nesnesini kapatıyoruz.
                DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                //Kullanıcıya silme onayı penceresi açıp, verdiği cevabı durum değişkenine aktardık.
                if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
                {
                    string silmeSorgusu = "DELETE from urunler where URUNAD=@URUNAD";
                    //musterino parametresine bağlı olarak ÜRÜN kaydını silen sql sorgusu
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@URUNAD", textBox4.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");
                    //Silme işlemini gerçekleştirdikten sonra kullanıcıya mesaj verdik.
                    this.Hide();
                    frmMutfak menu = new frmMutfak();
                    menu.Show();
                }
            }
            else
                MessageBox.Show("Urun Bulunamadı.");
            baglanti.Close();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)

                    baglanti.Open();
                string kayit = "insert into urunler (URUNAD, FIYAT, KATEGORI) values(@URUNAD, @FIYAT,@KATEGORI) ";
                komut = new SqlCommand(kayit, baglanti);

                
                komut.Parameters.AddWithValue("@URUNAD", textBox2.Text);
                komut.Parameters.AddWithValue("@FIYAT", textBox3.Text);
                komut.Parameters.AddWithValue("@KATEGORI", textBox1.Text);



                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün Kayıt İşlemi Gerçekleşti.");
                this.Hide();
                frmMutfak menu = new frmMutfak();
                menu.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.ToUpper();
            textBox2.SelectionStart = textBox2.Text.Length;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

