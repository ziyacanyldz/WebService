using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace PersonelManagerLibrary
{
    
    public class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Maas { get; set; }
        public string Sehir { get; set; }
        public string Meslek { get; set; }
        public string TelNo { get; set; }
    }


    public class PersonelManager
    {
        SqlConnection baglanti;

        public PersonelManager()
        {
            baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString);
        }

        public bool Ekle(Personel personel)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("sp_add", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.Parameters.Add(new SqlParameter("@ad", personel.Ad));
            komut2.Parameters.Add(new SqlParameter("@soyad", personel.Soyad));
            komut2.Parameters.Add(new SqlParameter("@maas", personel.Maas));
            komut2.Parameters.Add(new SqlParameter("@sehir", personel.Sehir));
            komut2.Parameters.Add(new SqlParameter("@meslek", personel.Meslek));
            komut2.Parameters.Add(new SqlParameter("@telno", personel.TelNo));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }

        public Personel GetirById(int id)
        {
            baglanti.Open();
            Personel personel = new Personel();

            SqlCommand komut2 = new SqlCommand("sp_GetirById", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.Parameters.Add(new SqlParameter("@ıd", id));

            SqlDataReader dr = komut2.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                personel.Id = Convert.ToInt32(dr["PerId"]);
                personel.Ad = dr["PerAd"].ToString();
                personel.Soyad = dr["PerSoyad"].ToString();
                personel.Maas = dr["PerMaas"].ToString();
                personel.Sehir = dr["PerAdres"].ToString();
                personel.Meslek = dr["PerMeslek"].ToString();
                personel.TelNo = dr["PerTelNo"].ToString();
            }

            baglanti.Close();

            return personel;
        }

        public DataTable GetirHepsi()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("sp_Listele", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = komut2.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            return dataTable;
        }

        public bool Guncelle(Personel personel)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("sp_Guncelle", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.Parameters.Add(new SqlParameter("@id", personel.Id));
            komut2.Parameters.Add(new SqlParameter("@ad", personel.Ad));
            komut2.Parameters.Add(new SqlParameter("@soyad", personel.Soyad));
            komut2.Parameters.Add(new SqlParameter("@maas", personel.Maas));
            komut2.Parameters.Add(new SqlParameter("@adres", personel.Sehir));
            komut2.Parameters.Add(new SqlParameter("@meslek", personel.Meslek));
            komut2.Parameters.Add(new SqlParameter("@telno", personel.TelNo));
            komut2.ExecuteNonQuery();
            /*
            baglanti.Close();
            return true;
            */
            SqlDataReader dr = komut2.ExecuteReader();
            dr.Read();
            if (dr["CevapKodu"].ToString() != "000")
            {
                baglanti.Close();
                return false;
            }

            baglanti.Close();
            return true;

        }

        public bool Sil(int id)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("sp_Sil", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.Parameters.Add(new SqlParameter("@id", id));
            // komut2.ExecuteNonQuery();
            // baglanti.Close();
            //return true;

            SqlDataReader dr = komut2.ExecuteReader();
            dr.Read();
            if (dr["CevapKodu"].ToString() != "000")
            {
                baglanti.Close();
                return false;
            }

            baglanti.Close();
            return true;
        }
    }
}
