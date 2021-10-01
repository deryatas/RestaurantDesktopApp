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
    class cyonetici
    {
        cGenel gnl = new cGenel(); // cGenel classını daha önce oluşturmuştuk burada cgenel classından nesnesini oluşturduk.
        #region fields
        private int _yoneticiId;
        private string _yoneticiAd;
        private string _yoneticiSoyad;
        private string _yoneticiParola;
        private string _yoneticiKullaniciAdi;

        internal bool PersonelEntryControl(string text)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public int yoneticiId { get => _yoneticiId; set => _yoneticiId = value; }
        public string yoneticiAd { get => _yoneticiAd; set => _yoneticiAd = value; }
        public string yoneticiSoyad { get => _yoneticiSoyad; set => _yoneticiSoyad = value; }
        public string yoneticiParola { get => yoneticiParola; set => yoneticiParola = value; }
        public string yoneticiKullaniciAdi { get => _yoneticiKullaniciAdi; set => _yoneticiKullaniciAdi = value; }
        #endregion

        public bool PersonelEntryControl(string password, int UserId) //Personel giriş.
        {

            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from yonetici where ID=@Id and PAROLA=@password", con);
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
        public void yoneticiGetbyInformation(ComboBox cb) //comboboxa giren personellerin değerini tutan fonksiyonum.
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from yonetici ", con);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cyonetici p = new cyonetici();
                p._yoneticiId = Convert.ToInt32(dr["ID"]);

                p._yoneticiAd = Convert.ToString(dr["AD"]);
                p._yoneticiSoyad = Convert.ToString(dr["SOYAD"]);
                p._yoneticiParola = Convert.ToString(dr["PAROLA"]);
                p._yoneticiKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                cb.Items.Add(p);

            }
            dr.Close();
            con.Close();
        }
        public override string ToString()
        {
            return yoneticiAd + " " + yoneticiSoyad;
        }
    }
}

