
using AuthenticationManagerLibrary;
using PersonelManagerLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Proje4WebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public bool Ekle(Personel personel)
        {
            PersonelManager personelManager = new PersonelManager();
            personelManager.Ekle(personel);
            return true;
        }
        [WebMethod]
        public Personel GetirById(int id)
        {
            
            PersonelManager personelManager = new PersonelManager();
            Personel personel = personelManager.GetirById(id);
            return personel;
        }

        [WebMethod]
        public bool Guncelle(Personel personel)
        {
            PersonelManager personelManager = new PersonelManager();

            return personelManager.Guncelle(personel);
        }

        [WebMethod]
        public bool Sil(int id)
        {
            PersonelManager personelManager = new PersonelManager();

            return personelManager.Sil(id);

        }

        [WebMethod]
        public DataTable GetirHepsi()
        {
            PersonelManager personelManager = new PersonelManager();
            DataTable dataTable = new DataTable();
            dataTable.TableName = "grid";
   
            return personelManager.GetirHepsi();
        }

        [WebMethod]
        public bool LoginKontrol(Kullanici kullanici)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager();
            return authenticationManager.LoginKontrol(kullanici);
        }

        [WebMethod]
        public bool YetkiliMi(Kullanici kullanici)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager();
            return authenticationManager.YetkiliMi(kullanici);
        }


        [WebMethod]
        public string sha256_hash(string value)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager();
            return authenticationManager.sha256_hash(value);
        }


        [WebMethod]
        public bool Ekle2(YeniKullanici kullanici)
        {
            AuthenticationManager authenticationManager = new AuthenticationManager();
            return authenticationManager.Ekle(kullanici);
        }
    }
}