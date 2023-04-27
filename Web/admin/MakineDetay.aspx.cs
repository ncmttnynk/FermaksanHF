using AjaxControlToolkit;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MakineDetay : IPage
{
    int makineId = 0;
    makineler makine = null;
    List<ListItem> aktarimSektor = new List<ListItem>();
    List<ListItem> aktarimKategori = new List<ListItem>();

    string FileName
    {
        get { return (string)(Session["FileName"] ?? ""); }
        set { Session["FileName"] = value; }
    }

    string Path
    {
        get { return (string)(Session["Path"] ?? ""); }
        set { Session["Path"] = value; }
    }

    string FotografAdi
    {
        get { return (string)(Session["FotografAdi"] ?? ""); }
        set { Session["FotografAdi"] = value; }
    }

    string FotografYol
    {
        get { return (string)(Session["FotografYol"] ?? ""); }
        set { Session["FotografYol"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        makineId = Request.QueryString["Id"].ToInt32();
        var mp = this.Master as IMP_Main;

        NYEditor ny = new NYEditor();
        ny.StandartAyarlar(ceMakineAciklama);
        ny.StandartAyarlar(ceMakineDetaylar);
        //ny.StandartAyarlar(ceMakineOzellikler);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "prepare Function", string.Format(@"function btnClick()
         {{
         var elem = $('#{0}');
         if (elem != null)
            elem.click();
            
         }}", btnUpload.ClientID), true);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "prepare Function2", string.Format(@"function btnFotografClick()
         {{
         var elemt = $('#{0}');
         if (elemt != null)
            elemt.click();
            
         }}", btnFotografUpload.ClientID), true);

        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        if (!IsPostBack)
        {
            using (var db = new FermaksanEntities())
            {
                lbSektorler.DataSource = db.sektorler.ToList();
                lbSektorler.DataTextField = "Baslik";
                lbSektorler.DataValueField = "Id";
                lbSektorler.DataBind();

                lbKategoriler.DataSource = db.kategoriler.ToList();
                lbKategoriler.DataTextField = "Baslik";
                lbKategoriler.DataValueField = "Id";
                lbKategoriler.DataBind();
            }

            if (makineId == 0)
            {
                mp.H1 = "Yeni Makine Ekle";
                mp.Title = "Yeni Makine Ekle";
                mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Makineler",Url="../admin/Makineler.aspx"},
                    new Info.BuradasinizInfo {Title="Yeni Makine Ekle"}
                };
                ltlFormBaslik.Text = "Yeni Makine Ekle";
            }
            else
            {
                using (var db = new FermaksanEntities())
                {
                    makine = db.makineler.FirstOrDefault(x => x.Id == makineId);
                    mp.H1 = makine.Baslik + " - " + makine.Kod;
                    mp.Title = makine.Baslik + " - " + makine.Kod;
                    ltlFormBaslik.Text = makine.Baslik + " - " + makine.Kod;
                    txtMakineBaslik.Text = makine.Baslik;
                    txtMakineKod.Text = makine.Kod;
                    txtMakineOncelik.Text = makine.Oncelik.ToString();
                    txtMakineVideo.Text = makine.Video;
                    ceMakineAciklama.Text = makine.Aciklama;
                    ceMakineDetaylar.Text = makine.Detay;
                    ceMakineOzellikler.Text = makine.Ozellikler;
                    //ceMakineOzellikler.Text = makine.Ozellikler;
                    if (!makine.Katalog.IsNullOrEmpty())
                    {
                        divKatalog.Visible = false;
                        divKatalogGoster.Visible = true;
                        hlKatalogGit.NavigateUrl = makine.Katalog;
                    }
                    lbSeciliSektorler.DataSource = (from x in db.s2m
                                                    join k in db.sektorler on x.SektorId equals k.Id
                                                    where x.MakineId == makineId
                                                    select new
                                                    {
                                                        k.Baslik,
                                                        k.Id
                                                    }).ToList();
                    lbSeciliSektorler.DataTextField = "Baslik";
                    lbSeciliSektorler.DataValueField = "Id";
                    lbSeciliSektorler.DataBind();
                    foreach (ListItem item in lbSeciliSektorler.Items)
                    {
                        lbSektorler.Items.Remove(item);
                    }

                    lbSeciliKategoriler.DataSource = (from x in db.k2m
                                                      join k in db.kategoriler on x.KategoriId equals k.Id
                                                      where x.MakineId == makineId
                                                      select new
                                                      {
                                                          k.Baslik,
                                                          k.Id
                                                      }).ToList();
                    lbSeciliKategoriler.DataTextField = "Baslik";
                    lbSeciliKategoriler.DataValueField = "Id";
                    lbSeciliKategoriler.DataBind();
                    foreach (ListItem item in lbSeciliKategoriler.Items)
                    {
                        lbKategoriler.Items.Remove(item);
                    }

                    FotograflariGetir();
                    mp.Buradasiniz = new List<Info.BuradasinizInfo>
                    {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Makineler",Url="../admin/Makineler.aspx"},
                    new Info.BuradasinizInfo {Title= makine.Baslik + " - " + makine.Kod }
                    };
                }
            }
        }
    }

    private void FotograflariGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var fotograflar = (from x in db.makinefotograflar
                               where x.MakineId == makineId
                               orderby x.Oncelik
                               select new
                               {
                                   x.Fotograf,
                                   x.Id
                               }).ToList();
            rptMakineFotograflar.DataSource = fotograflar;
            rptMakineFotograflar.DataBind();
        }
    }
    protected void btnSektorEkle_Click(object sender, EventArgs e)
    {
        if (lbSektorler.SelectedItem == null)
        {
            MessageBox.Show("Sektör seçiniz!", MessageBox.MesajTipleri.Warning);
        }
        foreach (ListItem li in lbSektorler.Items)
        {
            if (li.Selected)
            {
                aktarimSektor.Add(li);
                lbSeciliSektorler.Items.Add(li);
                lbSeciliSektorler.ClearSelection();
                lbSeciliSektorler.Sort();
            }
        }

        foreach (ListItem lbs in aktarimSektor)
        {
            lbSektorler.Items.Remove(lbs);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        divKatalog.Visible = false;
        divKatalogGoster.Visible = true;
        hlKatalogGit.NavigateUrl = (Path + FileName).Substring(1);
    }

    protected void btnFotografUpload_Click(object sender, EventArgs e)
    {
        using (var db = new FermaksanEntities())
        {
            makinefotograflar yeniFoto = new makinefotograflar
            {
                Fotograf = (FotografYol + FotografAdi).Substring(1),
                MakineId = makineId,
                Oncelik = 1000,
                Goster = true
            };
            db.makinefotograflar.Add(yeniFoto);
            db.SaveChanges();
            MessageBox.Show("Fotoğraf kayıt edildi!", MessageBox.MesajTipleri.Success);
            FotograflariGetir();
        }
    }

    protected void btnSektorCikar_Click(object sender, EventArgs e)
    {
        if (lbSeciliSektorler.SelectedItem == null)
        {
            MessageBox.Show("Sektör seçiniz!", MessageBox.MesajTipleri.Warning);
        }
        foreach (ListItem li in lbSeciliSektorler.Items)
        {
            if (li.Selected)
            {
                aktarimSektor.Add(li);
                lbSektorler.Items.Add(li);
                lbSektorler.ClearSelection();
                lbSektorler.Sort();
            }
        }

        foreach (ListItem lbs in aktarimSektor)
        {
            lbSeciliSektorler.Items.Remove(lbs);
        }

    }

    protected void btnKategoriCikar_Click(object sender, EventArgs e)
    {
        if (lbSeciliKategoriler.SelectedItem == null)
        {
            MessageBox.Show("Kategori seçiniz!", MessageBox.MesajTipleri.Warning);
        }
        foreach (ListItem li in lbSeciliKategoriler.Items)
        {
            if (li.Selected)
            {
                aktarimKategori.Add(li);
                lbKategoriler.Items.Add(li);
                lbKategoriler.ClearSelection();
                lbKategoriler.Sort();
            }
        }

        foreach (ListItem lbs in aktarimKategori)
        {
            lbSeciliKategoriler.Items.Remove(lbs);
        }
    }

    protected void btnKategoriEkle_Click(object sender, EventArgs e)
    {
        if (lbKategoriler.SelectedItem == null)
        {
            MessageBox.Show("Kategori seçiniz!", MessageBox.MesajTipleri.Warning);
        }
        foreach (ListItem li in lbKategoriler.Items)
        {
            if (li.Selected)
            {
                aktarimKategori.Add(li);
                lbSeciliKategoriler.Items.Add(li);
                lbSeciliKategoriler.ClearSelection();
                lbSeciliKategoriler.Sort();
            }
        }

        foreach (ListItem lbs in aktarimKategori)
        {
            lbKategoriler.Items.Remove(lbs);
        }
    }

    protected void fu_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        try
        {
            if (fuMakineKatalog.HasFile)
            {
                FileName = fuMakineKatalog.FileName;
                Path = string.Format("~/upload/kataloglar/{0}/{1}/{2}/", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                if (!Directory.Exists(Server.MapPath(Path)))
                    Directory.CreateDirectory(Server.MapPath(Path));
                fuMakineKatalog.SaveAs(Server.MapPath(Path) + FileName);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bir hata oluştu!", MessageBox.MesajTipleri.Error);
        }
    }

    protected void fuMakineFotograf_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        try
        {
            if (fuMakineFotograf.HasFile)
            {
                FotografAdi = fuMakineFotograf.FileName;
                FotografYol = string.Format("~/upload/makineler/{0}/{1}/{2}/", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                if (!Directory.Exists(Server.MapPath(FotografYol)))
                    Directory.CreateDirectory(Server.MapPath(FotografYol));
                fuMakineFotograf.SaveAs(Server.MapPath(FotografYol) + FotografAdi);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bir hata oluştu!", MessageBox.MesajTipleri.Error);
        }
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        var kod = txtMakineKod.Text;
        var baslik = txtMakineBaslik.Text;
        var oncelik = txtMakineOncelik.Text.ToInt32();
        var aciklama = ceMakineAciklama.Text;
        var detaylar = ceMakineDetaylar.Text;
        var ozelliker = ceMakineOzellikler.Text;
        var video = (!txtMakineVideo.Text.IsNullOrEmpty() ? txtMakineVideo.Text.Replace("watch?v=", "embed/") : "");
        var goster = cbMakineGoster.Checked;
        var katalog = "";
        if (!Path.IsNullOrEmpty() && !FileName.IsNullOrEmpty())
        {
            katalog = Path + FileName.Substring(1);
        }
        if (makineId == 0)
        {
            using (var db = new FermaksanEntities())
            {
                makine = new makineler
                {
                    Aciklama = aciklama,
                    Baslik = baslik,
                    Detay = detaylar,
                    DilKod = DilKod,
                    Goster = goster,
                    Katalog = (!katalog.IsNullOrEmpty() ? katalog : ""),
                    Kod = kod,
                    Oncelik = oncelik,
                    Ozellikler = ozelliker,
                    Video = video
                };

                db.makineler.Add(makine);
                db.SaveChanges();

                var fotograflar = db.makinefotograflar.Where(x => x.MakineId == 0).ToList();
                foreach (var f in fotograflar)
                {
                    f.MakineId = makine.Id;
                    db.SaveChanges();
                }

            }
        }
        else
        {
            using (var db = new FermaksanEntities())
            {
                makine = db.makineler.FirstOrDefault(x => x.Id == makineId);
                makine.Baslik = baslik;
                makine.Aciklama = aciklama;
                makine.Detay = detaylar;
                makine.Goster = goster;
                makine.Kod = kod;
                if (!Path.IsNullOrEmpty())
                {
                    makine.Katalog = (Path + FileName).Substring(1);
                }
                makine.Oncelik = oncelik;
                makine.Ozellikler = ozelliker;
                makine.Video = video;
                db.SaveChanges(); // Burada bir sıkıntı var o da şu: karşılaştırma yapıp silmek lazım...

                var kategoriler = db.k2m.Where(x => x.MakineId == makine.Id).ToList();
                foreach (var k in kategoriler)
                {
                    db.k2m.Remove(k);
                    db.SaveChanges();
                }
                var sektorler = db.s2m.Where(x => x.MakineId == makine.Id).ToList();
                foreach (var s in sektorler)
                {
                    db.s2m.Remove(s);
                    db.SaveChanges();
                }
            }
        }
        using (var db = new FermaksanEntities())
        {
            foreach (ListItem liS in lbSeciliSektorler.Items)
            {
                s2m makineSektor = new s2m
                {
                    MakineId = makine.Id,
                    SektorId = liS.Value.ToInt32()
                };
                db.s2m.Add(makineSektor);
                db.SaveChanges();
            }
            foreach (ListItem li in lbSeciliKategoriler.Items)
            {
                k2m makineKategori = new k2m
                {
                    MakineId = makine.Id,
                    KategoriId = li.Value.ToInt32()
                };
                db.k2m.Add(makineKategori);
                db.SaveChanges();
            }
        }
        MessageBox.Show("Makine başarıyla kayıt edildi!", MessageBox.MesajTipleri.Success);
        System.Threading.Thread.Sleep(1500);
        Response.Redirect("/admin/Makineler.aspx", true);
    }

    protected void lbKatalogSil_Click(object sender, EventArgs e)
    {
        DosyaDB dosyaDB = new DosyaDB();
        divKatalog.Visible = true;
        divKatalogGoster.Visible = false;
        dosyaDB.ResimSil(Path + FileName);
    }

    protected void rptMakineFotograflar_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int id = e.CommandArgument.ToInt32();
        if (id > 0)
        {
            using (var db = new FermaksanEntities())
            {
                var fotograf = db.makinefotograflar.FirstOrDefault(x => x.Id == id);
                DosyaDB dosyaDB = new DosyaDB();
                dosyaDB.ResimSil(fotograf.Fotograf);
                db.makinefotograflar.Remove(fotograf);
                db.SaveChanges();
                FotograflariGetir();
                MessageBox.Show("Fotoğraf silindi!", MessageBox.MesajTipleri.Success);
            }
        }
    }
}
