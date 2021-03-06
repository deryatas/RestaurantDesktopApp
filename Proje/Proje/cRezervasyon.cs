using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class cRezervasyon
    {
        #region fields
        private int _ID;
        private int _MASANO;
        private int _DURUM;
        private int _TARIH;
        private int _KULLANICIADI;

        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int MASANO { get => _MASANO; set => _MASANO = value; }
        public int DURUM { get => _DURUM; set => _DURUM = value; }
        public int TARIH { get => _TARIH; set => _TARIH = value; }
        public int KULLAINICIADI { get => _KULLANICIADI; set => _KULLANICIADI = value; }

        #endregion

        cGenel gnl = new cGenel();
        public string SessionSum(int state, string masaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH,MASAID From adisyonlar Right Join rezervasyon on adisyonlar.MASAID=masalar.MASANO Where masalar.DURUM=@durum and adisyonlar.Durum=0 and masalar.MASANO=@masaId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = masaId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
            return dt;

        }
        public int MasaNosu(string TableValue)
        {
            string a = TableValue;
            int lenght = a.Length;
            if (lenght > 8) { return Convert.ToInt32(a.Substring(lenght - 2, 2)); }
            else
            { return Convert.ToInt32(a.Substring(lenght - 1, 1)); }
        }
        public bool MasaDurumu(int ButtonName, int state)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select durum From rezervasyon Where MASANO=@ButtonName and DURUM=@state", con);
            cmd.Parameters.Add("@ButtonName", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                sonuc = Convert.ToBoolean(cmd.ExecuteScalar());

            }
            catch (SqlException ex)
            { string hata = ex.Message; }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        public void MasaDurumuDegistir(string ButtonName, int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("UPDATE rezervasyon SET DURUM=@Durum where MASANO=@MASANO", con);
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            string a = ButtonName;
            int uzunluk = a.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if (uzunluk > 8)
            {
                cmd.Parameters.Add("@MASANO", SqlDbType.Int).Value = a.Substring(uzunluk - 2, 2);
            }
            else
            {
                cmd.Parameters.Add("@MASANO", SqlDbType.Int).Value = a.Substring(uzunluk - 1, 1);
            }

            cmd.ExecuteNonQuery();
            con.Dispose(); con.Close();
        }
    }
}
