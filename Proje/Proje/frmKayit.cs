using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sql bağlantısı için ekliyoruz.

namespace Proje
{
    public partial class frmKayit : Form
    {
        public frmKayit()
        {
            InitializeComponent();
        }

        private void frmKayit_Load(object sender, EventArgs e)
        {

        }
        static string constring = ("Data Source=localhost;Initial Catalog=akdeniz;Integrated Security=True"); //veritabanı bağlantımız.
        SqlConnection baglan = new SqlConnection(constring);
        private SqlCommand komut;

        private void btnKayit_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)

                    baglan.Open();
                string kayit = "insert into kullanici (AD, SOYAD, PAROLA, KULLANICIADI, TELEFON ,ADRES ) values(@AD, @SOYAD, @PAROLA, @KULLANICIADI, @TELEFON, @ADRES) ";
                komut = new SqlCommand(kayit, baglan);

                komut.Parameters.AddWithValue("@AD", textBox1.Text);
                komut.Parameters.AddWithValue("@SOYAD", textBox2.Text);
                komut.Parameters.AddWithValue("@KULLANICIADI", textBox3.Text);
                komut.Parameters.AddWithValue("@PAROLA", textBox4.Text);
                komut.Parameters.AddWithValue("@TELEFON", textBox5.Text);
                komut.Parameters.AddWithValue("@ADRES", textBox6.Text);


                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
                this.Hide();
                frmKullaniciGiris menu = new frmKullaniciGiris();
                menu.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullanici menu = new frmKullanici();
            menu.Show();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }
    }

}
