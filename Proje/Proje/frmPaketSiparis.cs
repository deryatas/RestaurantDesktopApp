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
    public partial class frmPaketSiparis : Form
    {
        public frmPaketSiparis()
        {
            InitializeComponent();
        }
        public static SqlConnection con = new SqlConnection ("Data Source=localhost;Initial Catalog=akdeniz;Integrated Security=True");
        private SqlCommand komut;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullaniciGiris menu = new frmKullaniciGiris();
            menu.Show();
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
            
           foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["URUNAD"].ToString());
            }
            con.Close();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {

            Getir();
            KullaniciGetir();
            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();
                string kayit = "insert into paketSiparis (URUNAD, FIYAT, TELEFON, ADRES) values(@URUNAD, @FIYAT,@TELEFON, @ADRES) ";
                komut = new SqlCommand(kayit, con);


                komut.Parameters.AddWithValue("@URUNAD", comboBox1.Text);
                komut.Parameters.AddWithValue("@FIYAT", textBox2.Text);
                komut.Parameters.AddWithValue("@TELEFON", textBox3.Text);
                komut.Parameters.AddWithValue("@ADRES", textBox1.Text);


                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ürün Kayıt İşlemi Gerçekleşti.");
                this.Hide();
                frmPaketSiparis menu = new frmPaketSiparis();
                menu.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void frmPaketSiparis_Load(object sender, EventArgs e)
        {
            Getir();
            KullaniciGetir();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from urunler where URUNAD= '"+comboBox1.SelectedItem.ToString() +"'" ;
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

       
        
        private void KullaniciGetir()
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
    }

