using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    class ckullanici
    {
        cGenel gnl = new cGenel(); // cGenel classını daha önce oluşturmuştuk burada cgenel classından nesnesini oluşturduk.
        #region fields
        private int _kullaniciId;
        private string _kullaniciAd;
        private string _kullaniciSoyad;
        private string _kullaniciParola;
        private string _kullaniciKullaniciAdi;

        internal bool PersonelEntryControl(string text)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public int kullaniciId { get => _kullaniciId; set => _kullaniciId = value; }
        public string kullaniciAd { get => _kullaniciAd; set => _kullaniciAd = value; }
        public string kullaniciSoyad { get => _kullaniciSoyad; set => _kullaniciSoyad = value; }
        public string kullaniciParola { get => kullaniciParola; set => kullaniciParola = value; }
        public string kullaniciKullaniciAdi { get => _kullaniciKullaniciAdi; set => _kullaniciKullaniciAdi = value; }
        #endregion

        public bool PersonelEntryControl(string password, int UserId) //Personel giriş.
        {

            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kullanici where ID=@Id and PAROLA=@password", con);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password; //Önce bunlar çalışıcak buradaki değerlerimi
                                                                                 //sorguma götürdü daha sonra try catch ile de kontrol edilecek.



            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;

        }

      

        public void kullaniciGetbyInformation(ComboBox cb) //comboboxa giren personellerin değerini tutan fonksiyonum.
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kullanici ", con);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ckullanici p = new ckullanici();
                p._kullaniciId = Convert.ToInt32(dr["ID"]);

                p._kullaniciAd = Convert.ToString(dr["AD"]);
                p._kullaniciSoyad = Convert.ToString(dr["SOYAD"]);
                p._kullaniciParola = Convert.ToString(dr["PAROLA"]);
                p._kullaniciKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                cb.Items.Add(p);

            }
            dr.Close();
            con.Close();
        }
        public override string ToString()
        {
            return kullaniciAd + " " + kullaniciSoyad;
        }
    }
}
