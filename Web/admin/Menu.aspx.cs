using DAL;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Menu : IPage
{
    int UstMenuId
    {
        get { return ViewState["USTMENUID"].ToInt32(); }
        set { ViewState["USTMENUID"] = value; }
    }
    int MenuKayitId
    {
        get { return ViewState["MENUKAYITID"].ToInt32(); }
        set { ViewState["MENUKAYITID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var mp = this.Master as IMP_Main;
        mp.H1 = "Menüler";
        mp.Title = "Menüler";
        mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Menüler"}
                };

        if (!IsPostBack)
        {
            UstMenuId = Request.QueryString["Id"].ToInt32();
            if (UstMenuId > 0)
            {
                using (var db = new FermaksanEntities())
                {
                    var b = db.anamenu.FirstOrDefault(x => x.Id == UstMenuId);
                    hlUst.NavigateUrl = string.Format("Menu.aspx?Id={0}", b.UstMenuId);
                    hlUst.Visible = true;
                }
            }
            KayitlariGetir();
        }
    }

    private void KayitlariGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kayitlar = (from x in db.anamenu
                            where x.UstMenuId == UstMenuId && x.DilKod == DilKod
                            orderby x.Oncelik
                            select new MenuInfo
                            {
                                Id = x.Id,
                                Oncelik = x.Oncelik,
                                Url = x.Url,
                                Goster = x.Goster,
                                Baslik = x.Baslik,
                                DilKod = x.DilKod
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
                KayitSil(id);
                var kayit = db.anamenu.FirstOrDefault(x => x.Id == id);
                db.anamenu.Remove(kayit);
                db.SaveChanges();
                KayitlariGetir(); // don't repeat your self!!
                MessageBox.Show("Menü başarıyla silindi!", MessageBox.MesajTipleri.Success);
            }
        }
        else if (e.CommandName.Equals("Guncelle"))
        {
            using (var db = new FermaksanEntities())
            {
                var k = db.anamenu.FirstOrDefault(x => x.Id == id);
                txtKayitBaslik.Text = k.Baslik;
                txtKayitOncelik.Text = k.Oncelik.ToString();
                txtKayitKod.Text = k.Url;
                pnlKayit.Style["display"] = "block";
                lblKayitBaslik.Text = "Kayıt Güncelleme";
                btnKayitKaydet.Text = "Güncelle";
                MenuKayitId = id;
            }
        }
    }
    private void KayitSil(int id)
    {
        using (var db = new FermaksanEntities())
        {
            var silinecekMenu = db.anamenu.FirstOrDefault(x => x.Id == id);
            var tumu = db.anamenu.Where(x => x.UstMenuId == silinecekMenu.Id).ToList();
            foreach (var item in tumu)
            {
                KayitSil(item.Id);
                db.anamenu.Remove(item);
            }
            db.SaveChanges();
            KayitlariGetir();
        }
    }
    protected void btnKodOlustur_Click(object sender, EventArgs e)
    {
        var baslik = txtKayitBaslik.Text.ToTemizMetin();
        txtKayitKod.Text = baslik.ToURL();
    }

    protected void btnYeni_Click(object sender, EventArgs e)
    {
        txtKayitBaslik.Focus();
        txtKayitBaslik.Text = "";
        txtKayitKod.Text = "";
        txtKayitOncelik.Text = "1000";
        MenuKayitId = 0;
        pnlKayit.Style["display"] = "block";
        lblKayitBaslik.Text = "Yeni Menü Ekleme";
        btnKayitKaydet.Text = "Ekle";
        ddlLinkTurleri.ClearSelection();
        ddlLinkler.Visible = false;
    }

    protected void btnKapatUst_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
    }

    protected void btnKayitKapat_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
    }

    protected void btnKayitKaydet_Click(object sender, EventArgs e)
    {
        MessageBox.Show(ddlLinkler.SelectedValue, MessageBox.MesajTipleri.Success);
        var baslik = txtKayitBaslik.Text.ToTemizMetin();
        var kod = txtKayitKod.Text.ToTemizMetin();
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
                using (var trx = db.Database.BeginTransaction())
                {
                    anamenu menu = null;
                    anamenu altMenu = null;
                    anamenu altMenuMakine = null;

                    if (MenuKayitId == 0)
                    {
                        menu = new anamenu
                        {
                            Baslik = baslik,
                            Oncelik = oncelik,
                            UstMenuId = UstMenuId,
                            Goster = cbKayitGoster.Checked,
                            Url = "/" + Dil + kod,
                            DilKod = DilKod
                        };
                        db.anamenu.Add(menu);
                        db.SaveChanges();
                        if (ddlLinkler.SelectedValue == "/Makineler")
                        {
                            var altKategoriler = db.kategoriler.Where(x => x.DilKod == DilKod && x.Goster).OrderBy(x => x.Oncelik).ToList();
                            foreach (var a in altKategoriler)
                            {
                                altMenu = new anamenu
                                {
                                    Baslik = a.Baslik,
                                    DilKod = a.DilKod,
                                    Goster = true,
                                    UstMenuId = menu.Id,
                                    Url = string.Format("/{1}/Makineler.aspx#{0}", a.Baslik.ToURL(), Dil),
                                    Oncelik = 1000
                                };
                                db.anamenu.Add(altMenu);
                                db.SaveChanges();

                                var kategoriMakineleri = (from x in db.makineler
                                                          join k in db.k2m on x.Id equals k.MakineId
                                                          where x.Goster && k.KategoriId == a.Id && x.DilKod == DilKod && k.MakineId == x.Id
                                                          select x).ToList();
                                foreach (var km in kategoriMakineleri)
                                {
                                    altMenuMakine = new anamenu();
                                    altMenuMakine.Baslik = km.Baslik;
                                    altMenuMakine.Oncelik = 1000;
                                    altMenuMakine.Url = string.Format("/{3}/MakineDetay/{0}/{1}/{2},product", km.Id, km.Baslik.ToURL(), km.Kod.ToURL(), Dil);
                                    altMenuMakine.UstMenuId = altMenu.Id;
                                    altMenuMakine.Goster = true;
                                    altMenuMakine.DilKod = 1;
                                    db.anamenu.Add(altMenuMakine);
                                    db.SaveChanges();
                                }
                            }
                        }
                        else if (ddlLinkler.SelectedValue == "/Sektorler")
                        {
                            var altSektorler = db.sektorler.Where(x => x.DilKod == DilKod && x.Goster).OrderBy(x => x.Oncelik);
                            foreach (var a in altSektorler)
                            {
                                altMenu = new anamenu
                                {
                                    Baslik = a.Baslik,
                                    DilKod = a.DilKod,
                                    Goster = true,
                                    UstMenuId = menu.Id,
                                    Url = string.Format("{2}/Sektorler/{0}/{1}", a.Id, a.Baslik.ToURL(), Dil),
                                    Oncelik = 1000
                                };
                                db.anamenu.Add(altMenu);
                            }
                        }
                        else if (ddlLinkTurleri.SelectedValue.ToInt32() == 2)
                        {
                            int baslikId = ddlLinkler.SelectedValue.ToInt32();
                            var altCms = db.cms.Where(x => x.AnaBaslikId == baslikId && x.BaslikId != 0).ToList();
                            foreach (var c in altCms)
                            {
                                altMenu = new anamenu
                                {
                                    Baslik = c.Baslik,
                                    DilKod = DilKod,
                                    Goster = true,
                                    Oncelik = 1000,
                                    Url = string.Format("/{0}/{1},content", Dil, c.Kod),
                                    UstMenuId = menu.Id
                                };
                                db.anamenu.Add(altMenu);
                            }
                        }
                        MessageBox.Show("Menü başarıyla eklendi!", MessageBox.MesajTipleri.Success);
                    }
                    else
                    {
                        menu = db.anamenu.FirstOrDefault(x => x.Id == MenuKayitId);
                        menu.Baslik = baslik;
                        menu.Url = kod;
                        menu.Goster = cbKayitGoster.Checked;
                        menu.Oncelik = oncelik;
                        MessageBox.Show("Menü başarıyla güncellendi!", MessageBox.MesajTipleri.Success);
                    }
                    db.SaveChanges();
                    trx.Commit();
                }
                pnlKayit.Style["display"] = "none";
                KayitlariGetir();
            }

        }
        catch (Exception ex)
        {
            lblHata.Text = ex.InnerException.InnerException.Message;
            divHata.Visible = true;
        }
    }

    protected void btnHataKapat_Click(object sender, EventArgs e)
    {
        divHata.Visible = false;
    }

    protected void gvKayitlar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            var kayit = e.Row.DataItem as MenuInfo;
            Literal ltlDil = e.Row.FindControl("ltlDil") as Literal;
            Literal ltlGoster = e.Row.FindControl("ltlGoster") as Literal;
            ltlGoster.Text = (kayit.Goster) ? "<i class='far fa-thumbs-up'></i>" : "<i class='far fa-thumbs-down'></i>";
            ltlDil.Text = (kayit.DilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"">" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English"">";
        }
    }

    protected void ddlLinkTurleri_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = ddlLinkTurleri.SelectedValue.ToInt32();
        ddlLinkler.Items.Clear();
        if (id == 0)
        {
            ddlLinkler.Visible =
            ddlLinkler.Enabled = false;
            btnKodOlustur.Visible = btnKodOlustur.Enabled = true;
            txtKayitBaslik.Text = "";
            txtKayitKod.Text = "";
            return;
        }
        else if (id == 1) // sabit sayfalar
        {
            ddlLinkler.Items.Add(new ListItem((DilKod == 1) ? "ANASAYFA" : "HOME", "/"));
            ddlLinkler.Items.Add(new ListItem((DilKod == 1) ? "MAKİNELER" : "MACHINES", "/Makineler"));
            ddlLinkler.Items.Add(new ListItem((DilKod == 1) ? "SEKTÖRLER" : "ENDUSTRIES", "/Sektorler"));
            ddlLinkler.Items.Add(new ListItem((DilKod == 1) ? "SERVİS TALEP FORMU" : "SERVICE REQUEST", "/Servis"));
            ddlLinkler.Items.Add(new ListItem((DilKod == 1) ? "İLETİŞİM" : "CONTACT US", "/Iletisim"));
        }
        else if (id == 2) // cms
        {
            using (var db = new FermaksanEntities())
            {
                var cms = (from x in db.cms
                           where x.Goster && x.DilKod == DilKod && x.BaslikId == 0
                           orderby x.Oncelik
                           select new
                           {
                               x.Baslik,
                               x.Id
                           }).ToList();
                ddlLinkler.DataSource = cms;
                ddlLinkler.DataTextField = "Baslik";
                ddlLinkler.DataValueField = "Id";
                ddlLinkler.DataBind();
            }
        }
        ddlLinkler.Items.Insert(0, new ListItem("(Seçiniz)", ""));
        ddlLinkler.Visible =
        ddlLinkler.Enabled = true;
        ddlLinkler.SelectedIndex = 0;
    }
    protected void ddlLinkler_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLinkler.SelectedItem == null) return;
        if (ddlLinkTurleri.SelectedValue.ToInt32() == 2) // CMS
            txtKayitKod.Text = "/" + ddlLinkler.SelectedItem.Text.ToString().ToURL() + ",content";
        else
            txtKayitKod.Text = ddlLinkler.SelectedValue;
        txtKayitBaslik.Text = ddlLinkler.SelectedItem.Text.Replace("└─ ", "").Replace("└─── ", "").Trim();
        btnKodOlustur.Visible = btnKodOlustur.Enabled = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtKayitBaslik.Text = ddlLinkler.SelectedValue;
    }
}