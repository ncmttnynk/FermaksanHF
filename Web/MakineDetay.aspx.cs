using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MakineDetay : IPage
{
    int makineId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        makineId = Request.QueryString["MakineId"].ToInt32();
        if (!IsPostBack)
        {
            ltlAltBaslik.Text = (Dil.Equals("tr") ? @"İLGİLİ <strong> ÇALIŞMALAR </strong>" : @"RELATED <strong> WORKS </strong>");
            //hlTumSag.NavigateUrl = "/" + Dil + "/Makineler.aspx";
            //hlTumSol.NavigateUrl = "/" + Dil + "/Makineler.aspx";
            if (makineId > 0)
            {
                using (var db = new FermaksanEntities())
                {
                    var makine = db.makineler.FirstOrDefault(x => x.Id == makineId && x.DilKod == DilKod && x.Goster);
                    if (makine != null)
                    {
                        ltlAciklama.Text = makine.Aciklama;
                        ltlMakineBaslik.Text = makine.Kod + " - " + makine.Baslik;
                        //ltlMakineKod.Text = makine.Kod;
                        ltlDetay.Text = makine.Detay;
                        pnlKullanildigi.Visible = (!string.IsNullOrEmpty(makine.Ozellikler));
                        ltlOzellik.Text = makine.Ozellikler;
                        if (!makine.Video.IsNullOrEmpty())
                        {
                            liVideo.Visible = divVideoContainer.Visible = true;
                            video.Attributes.Add("src", makine.Video);
                        }
                        if (!makine.Katalog.IsNullOrEmpty())
                        {
                            liKatalog.Visible = true;
                            hlKatalog.NavigateUrl = makine.Katalog;
                        }

                        var kategoriMakineleri = (from x in db.makineler
                                                  join y in db.k2m on x.Id equals y.MakineId
                                                  join p in db.kategoriler on y.KategoriId equals p.Id
                                                  where x.Goster && x.DilKod == DilKod && x.Id != makineId
                                                  orderby MyDbFunction.Rastgele()
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
                                                  }).Take(4).ToList();
                        if (kategoriMakineleri.Count > 0)
                        {
                            rptIlgiliMakineler.DataSource = kategoriMakineleri.ToList();
                            rptIlgiliMakineler.DataBind();
                            pnlIlgılı.Visible = true;
                        }
                        var makineFotograflari = from x in db.makinefotograflar
                                                 where x.MakineId == makineId && x.Goster
                                                 orderby x.Oncelik
                                                 select new
                                                 {
                                                     x.Fotograf,
                                                     makine.Baslik,
                                                     makine.Kod
                                                 };
                        rptMakineFotograf.DataSource = makineFotograflari.ToList();
                        rptMakineFotograf.DataBind();

                        var kategori = (from x in db.k2m
                                        join k in db.kategoriler on x.KategoriId equals k.Id
                                        where x.MakineId == makineId
                                        select k.Baslik).FirstOrDefault();
                        base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
                       {
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"},
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Makineler" : "Machines"),Url="/"+Dil+"/Makineler"},
                              new Info.BuradasinizInfo {Title=kategori,Url="/"+Dil+"/Makineler#"+kategori.ToString().ToURL()},
                              new Info.BuradasinizInfo {Title=makine.Kod+" - " + makine.Baslik},
                       };
                        base.MP_Main.Title = makine.Baslik + " - " + makine.Kod;
                        base.MP_Main.H1 = makine.Baslik;
                    }
                    else
                    {
                        Response.Redirect("/" + Dil + "/Default.aspx");
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}