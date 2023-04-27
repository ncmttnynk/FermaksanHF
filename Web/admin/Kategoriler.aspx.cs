using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Kategoriler : IPage
{
    int KategoriKayitId
    {
        get { return ViewState["KATEGORIKAYITID"].ToInt32(); }
        set { ViewState["KATEGORIKAYITID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var mp = this.Master as IMP_Main;
        mp.H1 = "Kategoriler";
        mp.Title = "Kategoriler";
        mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Kategoriler"}
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
            var kayitlar = (from x in db.kategoriler
                            where x.DilKod == DilKod
                            orderby x.Oncelik
                            select new Info.KategoriInfo
                            {
                                Id = x.Id,
                                Oncelik = x.Oncelik,
                                Goster = x.Goster,
                                Baslik = x.Baslik,
                                DilKod = DilKod
                            });
            var toplam = kayitlar.Count();
            UC_Sayfalama2.Toplam = toplam;
            UC_Sayfalama2.Adet = 10;
            UC_Sayfalama2.Sayfala();
            UC_Sayfalama1.Toplam = toplam;
            UC_Sayfalama1.Adet = 10;
            UC_Sayfalama1.Sayfala();
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
            using (var db = new FermaksanEntities())
            {
                var kayit = db.kategoriler.FirstOrDefault(x => x.Id == id);
                var kayitMakineler = db.k2m.Where(x => x.KategoriId == id).ToList();
                foreach (var k in kayitMakineler)
                {
                    db.k2m.Remove(k);
                }
                db.kategoriler.Remove(kayit);
                db.SaveChanges();
                MessageBox.Show("Kategori başarıyla silindi!", MessageBox.MesajTipleri.Success, true, 1500);
                KayitlariGetir();
            }
        }
        else if (e.CommandName.Equals("Guncelle"))
        {
            using (var db = new FermaksanEntities())
            {
                var k = db.kategoriler.FirstOrDefault(x => x.Id == id);
                txtKayitBaslik.Text = k.Baslik;
                txtKayitOncelik.Text = k.Oncelik.ToString();
                pnlKayit.Style["display"] = "block";
                lblKayitBaslik.Text = "Kategori Kayıt Güncelleme";
                btnKayitKaydet.Text = "Güncelle";
                KategoriKayitId = id;
            }
        }
    }

    protected void btnYeni_Click(object sender, EventArgs e)
    {
        txtKayitBaslik.Focus();
        txtKayitBaslik.Text = "";
        txtKayitOncelik.Text = "1000";
        KategoriKayitId = 0;
        pnlKayit.Style["display"] = "block";
        lblKayitBaslik.Text = "Yeni Kategori Ekleme";
        btnKayitKaydet.Text = "Ekle";
    }

    protected void btnKayitKapat_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
    }

    protected void btnKayitKaydet_Click(object sender, EventArgs e)
    {
        var baslik = txtKayitBaslik.Text.ToTemizMetin();
        var oncelik = txtKayitOncelik.Text.ToInt32();

        if (baslik.IsNullOrEmpty())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),
                @"alert('Başlık bilgisi girmelisiniz!');", true);
            txtKayitBaslik.Focus();
            return;
        }

        try
        {
            using (var db = new FermaksanEntities())
            {
                kategoriler kategori = null;
                if (KategoriKayitId == 0)
                {
                    kategori = new kategoriler
                    {
                        Baslik = baslik,
                        Oncelik = oncelik,
                        Goster = cbKayitGoster.Checked,
                        DilKod = DilKod
                    };
                    db.kategoriler.Add(kategori);
                }
                else
                {
                    kategori = db.kategoriler.FirstOrDefault(x => x.Id == KategoriKayitId);
                    kategori.Baslik = baslik;
                    kategori.Goster = cbKayitGoster.Checked;
                    kategori.Oncelik = oncelik;
                }
                db.SaveChanges();
                pnlKayit.Style["display"] = "none";
                KayitlariGetir();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnKapatUst_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
    }

    protected void gvKayitlar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            var kayit = e.Row.DataItem as Info.KategoriInfo;
            Literal ltlDil = e.Row.FindControl("ltlDil") as Literal;
            Literal ltlGoster = e.Row.FindControl("ltlGoster") as Literal;
            ltlGoster.Text = (kayit.Goster) ? "<i class='far fa-thumbs-up'></i>" : "<i class='far fa-thumbs-down'></i>";
            ltlDil.Text = (kayit.DilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"">" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English"">";
        }
    }
}