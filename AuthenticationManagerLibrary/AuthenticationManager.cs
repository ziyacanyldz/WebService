using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationManagerLibrary
{
    public class Kullanici
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }

    public class YeniKullanici
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public bool Yetki { get; set; }
    }

    public class AuthenticationManager
    {

        SqlConnection baglanti;

        public AuthenticationManager()
        {
            baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString);
            baglanti.Open();
        }

        public bool LoginKontrol(Kullanici kullanici)
        {

            SqlCommand komut2 = new SqlCommand("sp_KullaniciLogin", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;

            komut2.Parameters.Add(new SqlParameter("@user", kullanici.KullaniciAdi));
            komut2.Parameters.Add(new SqlParameter("@pass", kullanici.Sifre));

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

        public bool YetkiliMi(Kullanici kullanici)
        {
           // baglanti.Open();
            SqlCommand komut2 = new SqlCommand("sp_kullaniciYetkiliMi", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;

            komut2.Parameters.Add(new SqlParameter("@user", kullanici.KullaniciAdi));
            komut2.Parameters.Add(new SqlParameter("@pass", kullanici.Sifre));

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

        public string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public bool Ekle(YeniKullanici kullanici)
        {
            SqlCommand komut2 = new SqlCommand("sp_KullaniciKaydet", baglanti);
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.Parameters.Add(new SqlParameter("@kulLanici", kullanici.KullaniciAdi));
            komut2.Parameters.Add(new SqlParameter("@sifre", kullanici.Sifre));
            komut2.Parameters.Add(new SqlParameter("@yetki", kullanici.Yetki));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            return true;
        }
    }
}
