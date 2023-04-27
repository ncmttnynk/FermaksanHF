using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Makineler : IPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var mp = this.Master as IMP_Main;
        mp.H1 = "Makineler";
        mp.Title = "Makineler";
        mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Makineler"}
                };
        if (!IsPostBack)
        {
            KayitlariGetir();
        }
    }

    private void KayitlariGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kayitlar = (from x in db.makineler
                            where x.DilKod == DilKod
                            orderby x.Oncelik
                            select new Info.MakineInfo
                            {
                                Id = x.Id,
                                Kod = x.Kod,
                                Oncelik = x.Oncelik,
                                DilKod = x.DilKod,
                                Goster = x.Goster,
                                Baslik = x.Baslik

                            });
            var toplam = kayitlar.Count();
            UC_Sayfalama1.Toplam = toplam;
            UC_Sayfalama1.Adet = 5;
            UC_Sayfalama1.Sayfala();
            UC_Sayfalama2.Toplam = toplam;
            UC_Sayfalama2.Adet = 5;
            UC_Sayfalama2.Sayfala();

            gvKayitlar.DataSource = kayitlar.Skip(UC_Sayfalama1.Baslangic).Take(UC_Sayfalama1.Adet).ToList();
            gvKayitlar.DataBind();

            if (gvKayitlar.HeaderRow != null)
                gvKayitlar.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void gvKayitlar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = e.CommandArgument.ToInt32();
        if (e.CommandName.Equals("Sil"))
        {
            DosyaDB dosyaDB = new DosyaDB();
            using (var db = new FermaksanEntities())
            {
                var kayit = db.makineler.FirstOrDefault(x => x.Id == id);
                var kayitKategorileri = db.k2m.Where(x => x.MakineId == id);
                var kayitSektorleri = db.s2m.Where(x => x.MakineId == id);
                var kayitFotograflari = db.makinefotograflar.Where(x => x.MakineId == id);
                foreach (var k in kayitKategorileri)
                {
                    db.k2m.Remove(k);
                }
                foreach (var s in kayitSektorleri)
                {
                    db.s2m.Remove(s);
                }
                foreach (var f in kayitFotograflari)
                {
                    db.makinefotograflar.Remove(f);
                    dosyaDB.ResimSil(f.Fotograf);
                }
                db.makineler.Remove(kayit);
                db.SaveChanges();
                MessageBox.Show("Makine başarıyla silindi!", MessageBox.MesajTipleri.Success, true, 1500);
                KayitlariGetir();
            }
        }
    }

    protected void gvKayitlar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            var kayit = e.Row.DataItem as Info.MakineInfo;
            Literal ltlDil = e.Row.FindControl("ltlDil") as Literal;
            Literal ltlGoster = e.Row.FindControl("ltlGoster") as Literal;
            ltlGoster.Text = (kayit.Goster) ? "<i class='far fa-thumbs-up'></i>" : "<i class='far fa-thumbs-down'></i>";
            ltlDil.Text = (kayit.DilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"">" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English"">";
        }
    }

    protected void btnYeni_Click(object sender, EventArgs e)
    {
        Session["Path"] = Session["FileName"] = "";
        Response.Redirect("/admin/MakineDetay.aspx?Id=0", true);
    }
}