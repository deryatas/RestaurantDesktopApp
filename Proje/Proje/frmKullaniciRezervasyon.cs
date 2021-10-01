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
    public partial class frmKullaniciRezervasyon : Form
    {
        public frmKullaniciRezervasyon()
        {
            InitializeComponent();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            int uzunluk = btnMasa1.Text.Length;

            cGenel._ButtonValue = btnMasa1.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa1.Name;
            this.Close();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            int uzunluk = btnMasa2.Text.Length;

            cGenel._ButtonValue = btnMasa2.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa2.Name;
            this.Close();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            int uzunluk = btnMasa3.Text.Length;

            cGenel._ButtonValue = btnMasa3.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa3.Name;
            this.Close();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            int uzunluk = btnMasa4.Text.Length;

            cGenel._ButtonValue = btnMasa4.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa4.Name;
            this.Close();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            int uzunluk = btnMasa5.Text.Length;

            cGenel._ButtonValue = btnMasa5.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa5.Name;
            this.Close();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            int uzunluk = btnMasa6.Text.Length;

            cGenel._ButtonValue = btnMasa6.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa6.Name;
            this.Close();
        }



        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden eminmisiniz?", "Uyarı..!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKullaniciGiris menu = new frmKullaniciGiris();
            menu.Show();
        }
        cGenel gnl = new cGenel();
        private void frmKullaniciRezervasyon_Load(object sender, EventArgs e)
        {
            getir();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,MASANO from rezervasyon", con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            dr = cmd.ExecuteReader(); while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnMasa" + dr["MASANO"].ToString() && dr["DURUM"].ToString() == "Rezervasyon")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.YENİLE__1_);
                        }
                        else if (item.Name == "btnMasa" + dr["MASANO"].ToString() && dr["DURUM"].ToString() == "HAYIR")
                        {
                            cRezervasyon ms = new cRezervasyon();
                            //DateTime dt1 = Convert.ToDateTime(ms.SessionSum(2,dr["ID"].ToString()));
                            //DateTime dt2 = DateTime.Now;
                            //string st1 = Convert.ToDateTime(ms.SessionSum(2,dr["ID"].ToString())).ToShortDateString();
                            //string st2 = DateTime.Now.ToShortTimeString();
                            //DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            //DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);
                            //var fark = t2 - t1;
                            //    item.Text=String.Format("{0}{1}{2}",
                            //    fark.Days>0 ? string.Format("{0} gün",fark.Days):"",
                            //    fark.Hours>0 ? string.Format("{0} saat",fark.Hours):"",
                            //    fark.Minutes>0 ? string.Format("{0} dakika",fark.Minutes):"").Trim()+"\n\n\nMasa"+dr["ID"].ToString();
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.YENİLE__2_);
                        }
                        else if (item.Name == "btnMasa" + dr["MASANO"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.MÜŞTERİ__15_);
                        }
                    }
                }
            }
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
                string kayit = "insert into rezervasyon (MASANO,DURUM,KULLANICIADI,TARIH) values(@MASANO,@DURUM,@KULLANICIADI,@TARIH) ";
                komut = new SqlCommand(kayit, baglan);

                komut.Parameters.AddWithValue("@MASANO", textBox2.Text);
                komut.Parameters.AddWithValue("@DURUM", comboBox1.Text);
                komut.Parameters.AddWithValue("@KULLANICIADI", textBox3.Text);
                komut.Parameters.AddWithValue("@TARIH", dateTimePicker1.Text);



                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show(textBox2.Text + " NOLU MASANIN" + dateTimePicker1.Text + " TARİHLİ " + textBox3.Text + "KİŞİNİN REZERVASYONU YAPILMIŞTIR");
                this.Hide();
                frmKullaniciGiris menu = new frmKullaniciGiris();
                menu.Show();
               
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Day < DateTime.Now.Day)
            {
                MessageBox.Show("Geçmişten bir tarih secemezsiniz");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
          
        }
        private void getir()
        {
            comboBox1.Items.Clear();
            baglan.Open();
            SqlCommand cmd = baglan.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DURUM from rezervasyon";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["DURUM"].ToString());
            }
            baglan.Close();
        }
    }
    }

