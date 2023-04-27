using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Info;

/// <summary>
/// Summary description for KategorilerWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class KategorilerWS : System.Web.Services.WebService
{

    public KategorilerWS()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]

    public List<KategoriInfo> TumKategorileriGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kategoriler = (from x in db.kategoriler
                              orderby x.Oncelik
                              select new KategoriInfo
                              {
                                  Baslik = x.Baslik,
                                  DilKod = x.DilKod,
                                  Oncelik = x.Oncelik,
                                  Goster = x.Goster
                              }).ToList();
            return kategoriler;
        }
    }

}
