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
    public partial class frmRezervasyon : Form
    {
        public frmRezervasyon()
        {
            InitializeComponent();
        }
        static string conString = ("Data Source=localhost;Initial Catalog=akdeniz;Integrated Security=True");
        SqlConnection baglanti = new SqlConnection(conString);
        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "Select * from rezervasyon ";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource= dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            baglanti.Close();
        }
        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            kayitGetir();
            kayitGetir1();
        }

        private void kayitGetir1()
        {
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
                        if (item.Name == "btnMasa" + dr["MASANO"].ToString() && dr["DURUM"].ToString() == "EVET")
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secmeSorgusu = "SELECT * from rezervasyon where ID=@ID";
            //musterino parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
            secmeKomutu.Parameters.AddWithValue("@ID", txtMusterino.Text);
            //musterino parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
            SqlDataReader dr = secmeKomutu.ExecuteReader();
            if (dr.Read()) //Datareader herhangi bir okuma yapabiliyorsa aşağıdaki kodlar çalışır.
            {
                string isim = dr["MASANO"].ToString() + " " + dr["DURUM"].ToString();
                dr.Close();
                //Datareader ile okunan müşteri ad ve soyadını isim değişkenine atadım.
                //Datareader açık olduğu sürece başka bir sorgu çalıştıramayacağımız için dr nesnesini kapatıyoruz.
                DialogResult durum = MessageBox.Show(isim + " kaydını silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                //Kullanıcıya silme onayı penceresi açıp, verdiği cevabı durum değişkenine aktardık.
                if (DialogResult.Yes == durum) // Eğer kullanıcı Evet seçeneğini seçmişse, veritabanından kaydı silecek kodlar çalışır.
                {
                    string silmeSorgusu = "DELETE from rezervasyon where ID=@ID";
                    //musterino parametresine bağlı olarak müşteri kaydını silen sql sorgusu
                    SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                    silKomutu.Parameters.AddWithValue("@ID", txtMusterino.Text);
                    silKomutu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi...");
                    //Silme işlemini gerçekleştirdikten sonra kullanıcıya mesaj verdik.
                }
            }
            else
                MessageBox.Show("Müşteri Bulunamadı.");
            baglanti.Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAyarlar menu = new frmAyarlar();
            menu.Show();
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
        cGenel gnl = new cGenel();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRezervasyon menu = new frmRezervasyon();
            menu.Show();
        }
    }

    }

