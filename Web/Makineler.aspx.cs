using Info;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Makineler : IPage
{
    int kategoriId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        kategoriId = Request.QueryString["KategoriId"].ToInt32();
        if (!IsPostBack)
        {
            using (var db = new FermaksanEntities())
            {
                var kategoriler = from x in db.kategoriler
                                  where x.Goster && x.DilKod == DilKod
                                  orderby x.Oncelik
                                  let Adet = (from t in db.k2m
                                              where t.KategoriId == x.Id
                                              select t).Count()
                                  select new KategoriInfo
                                  {
                                      Id = x.Id,
                                      Baslik = x.Baslik,
                                      Adet = Adet
                                  };
                rptKategoriler.DataSource = kategoriler.ToList();
                rptKategoriler.DataBind();
            }
            if (kategoriId == 0)
            {
                TumMakineleriGetir();
                base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
                      {
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"+Dil+"/Default.aspx"},
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Makineler" : "Machines")},
                      };
                base.MP_Main.Title = (Dil.Equals("tr") ? "Makineler" : "Machines");
                base.MP_Main.H1 = (Dil.Equals("tr") ? "Makineler" : "Machines");
            }
            else
            {
                KategoriMakineleriniGetir(kategoriId);
                using (var db = new FermaksanEntities())
                {
                    var kat = db.kategoriler.FirstOrDefault(x => x.Id == kategoriId);
                    base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
                      {
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"+Dil+"/Default.aspx"},
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Makineler" : "Machines"), Url="/"+Dil+"/Makineler.aspx"},
                              new Info.BuradasinizInfo {Title=kat.Baslik}
                      };
                    base.MP_Main.Title = kat.Baslik;
                    base.MP_Main.H1 = kat.Baslik;
                }
            }
        }
    }

    private void KategoriMakineleriniGetir(int katId)
    {
        using (var db = new FermaksanEntities())
        {
            var kategoriMakineleri = from x in db.makineler
                                     join y in db.k2m on x.Id equals y.MakineId
                                     join p in db.kategoriler on y.KategoriId equals p.Id
                                     where x.Goster && x.DilKod == DilKod && y.KategoriId == katId
                                     orderby x.Oncelik
                                     let makineFoto = (from c in db.makinefotograflar
                                                       where c.MakineId == x.Id
                                                       orderby c.Oncelik
                                                       select c).FirstOrDefault()
                                     select new
                                     {
                                         x.Id,
                                         x.Baslik,
                                         x.Kod,
                                         Kategori = p.Baslik,
                                         Fotograf = (makineFoto == null) ? "/img/projects/project.jpg" : makineFoto.Fotograf
                                     };
            rptMakineler.DataSource = kategoriMakineleri.ToList();
            rptMakineler.DataBind();
        }
    }
    private void TumMakineleriGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kategoriMakineleri = from x in db.makineler
                                     join k in db.k2m on x.Id equals k.MakineId
                                     join t in db.kategoriler on k.KategoriId equals t.Id
                                     where x.Goster && x.DilKod == DilKod
                                     orderby x.Oncelik
                                     let makineFoto = (from l in db.makinefotograflar
                                                       where l.MakineId == x.Id
                                                       orderby l.Oncelik
                                                       select l).FirstOrDefault()
                                     select new
                                     {
                                         x.Id,
                                         x.Baslik,
                                         x.Kod,
                                         Kategori = t.Baslik,
                                         Fotograf = (makineFoto == null) ? "/img/projects/project.jpg" : makineFoto.Fotograf
                                     };
            rptMakineler.DataSource = kategoriMakineleri.ToList();
            rptMakineler.DataBind();
        }
    }

    protected void rptKategoriler_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var kayit = e.Item.DataItem as KategoriInfo;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (kategoriId > 0)
            {
                if (kayit.Id == kategoriId)
                {
                    HtmlControl liKat = e.Item.FindControl("liKat") as HtmlControl;
                    HtmlControl aKat = e.Item.FindControl("aKat") as HtmlControl;
                    liKat.Attributes.Add("class", liKat.Attributes["class"] + " active");
                    aKat.Attributes.Add("class", aKat.Attributes["class"] + " active");
                }
            }
        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            HtmlControl aHepsi = e.Item.FindControl("aHepsi") as HtmlControl;
            HtmlControl liHepsi = e.Item.FindControl("liHepsi") as HtmlControl;
            aHepsi.Attributes.Add("href", "/" + Dil + "/Makineler.aspx");
            if (kategoriId == 0)
            {
                liHepsi.Attributes.Add("class", liHepsi.Attributes["class"] + " active");
                aHepsi.Attributes.Add("class", aHepsi.Attributes["class"] + " active");
            }
        }
    }
}