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
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmAyarlar frm = new frmAyarlar();
            this.Close();
            frm.Show();
        }
        

        public static SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=akdeniz;Integrated Security=True");
        private SqlCommand komut;
        private void frmSiparis_Load(object sender, EventArgs e)
        {

            Getir();
            
           
        }
        private void Getir()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT URUNAD from urunler";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["URUNAD"].ToString());
            }
            con.Close();
        }


        private void btnAnaYemek_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnIcecekler_Click(object sender, EventArgs e)
        {
          
        }

        private void btnCorba_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from urunler where URUNAD= '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["FIYAT"].ToString();
            }
            con.Close();

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMusterino_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            Getir();
            try
            {
                if (con.State == ConnectionState.Closed)

                con.Open();
                string kayit = "insert into siparis (URUNAD, FIYAT, MASANO) values(@URUNAD, @FIYAT,@MASANO) ";
              
                komut = new SqlCommand(kayit, con);


                komut.Parameters.AddWithValue("@URUNAD", comboBox1.Text);
                komut.Parameters.AddWithValue("@FIYAT", textBox2.Text);
                komut.Parameters.AddWithValue("@MASANO", textBox1.Text);

                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("SİPARİŞ VERİLDİ.");
                this.Hide();
                frmSiparis menu = new frmSiparis();
                menu.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string secmeSorgusu = "SELECT * from siparis where URUNAD=@URUNAD";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, con);
            secmeKomutu.Parameters.AddWithValue("@URUNAD", txtMusterino.Text);
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
                    string silmeSorgusu = "DELETE from siparis where URUNAD=@URUNAD";
                    //musterino parametresine bağlı olarak ÜRÜN kaydını silen sql sorgusu
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, con);
                    silKomutu.Parameters.AddWithValue("@URUNAD", txtMusterino.Text);
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
            con.Close();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        cGenel gnl = new cGenel();
       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
