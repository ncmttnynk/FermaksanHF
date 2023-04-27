using AjaxControlToolkit;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Sektorler : IPage
{
    int SektorKayitId
    {
        get { return ViewState["SEKTORKAYITID"].ToInt32(); }
        set { ViewState["SEKTORKAYITID"] = value; }
    }

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

    protected void Page_Load(object sender, EventArgs e)
    {
        var mp = this.Master as IMP_Main;
        mp.H1 = "Sektörler";
        mp.Title = "Sektörler";
        mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Sektörler"}
                };
        NYEditor ny = new NYEditor();
        ny.StandartAyarlar(ceKayitAciklama);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "prepare Function", string.Format(@"function btnClick()
         {{
         var elem = $('#{0}');
         if (elem != null)
            elem.click();
            
         }}", btnUpload.ClientID), true);

        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        if (!IsPostBack)
        {
            KayitlariGetir();
        }
    }

    private void KayitlariGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kayitlar = (from x in db.sektorler
                            where x.DilKod == DilKod
                            orderby x.Oncelik
                            select new Info.SektorInfo
                            {
                                Id = x.Id,
                                Oncelik = x.Oncelik,
                                Goster = x.Goster,
                                Baslik = x.Baslik,
                                DilKod = x.DilKod
                                //Aciklama = x.Aciklama
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
                var kayit = db.sektorler.FirstOrDefault(x => x.Id == id);
                var kayitMakineler = db.s2m.Where(x => x.SektorId == id).ToList();
                foreach (var k in kayitMakineler)
                {
                    db.s2m.Remove(k);
                }
                db.sektorler.Remove(kayit);
                db.SaveChanges();
                MessageBox.Show("Sektör başarıyla silindi!", MessageBox.MesajTipleri.Success, true, 1500);
                KayitlariGetir();
            }
        }
        else if (e.CommandName.Equals("Guncelle"))
        {
            using (var db = new FermaksanEntities())
            {
                var k = db.sektorler.FirstOrDefault(x => x.Id == id);
                txtKayitBaslik.Text = k.Baslik;
                txtKayitOncelik.Text = k.Oncelik.ToString();
                pnlKayit.Style["display"] = "block";
                lblKayitBaslik.Text = "Sektör Kayıt Güncelleme";
                btnKayitKaydet.Text = "Güncelle";
                if (!k.Fotograf.IsNullOrEmpty())
                {
                    divFotografGoster.Visible = true;
                    divFotoUpload.Visible = false;
                    imgSektor.ImageUrl =  k.Fotograf;
                    imgSektor.AlternateText = k.Fotograf;
                    imgSektor.ToolTip = k.Fotograf;
                }
                SektorKayitId = id;
            }
        }
    }

    protected void btnKapatUst_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
    }


    protected void btnYeni_Click(object sender, EventArgs e)
    {
        txtKayitBaslik.Focus();
        txtKayitBaslik.Text = "";
        txtKayitOncelik.Text = "1000";
        SektorKayitId = 0;
        pnlKayit.Style["display"] = "block";
        lblKayitBaslik.Text = "Yeni Sektör Ekleme";
        btnKayitKaydet.Text = "Ekle";
        divFotografGoster.Visible = false;
        divFotoUpload.Visible = true;
        ceKayitAciklama.Text = "";
    }

    protected void btnKayitKapat_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
    }

    protected void fu_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
    {
        try
        {
            if (fu.HasFile)
            {
                int poz = fu.FileName.LastIndexOf(".");
                string uzanti = fu.FileName.Substring(poz + 1);
                FileName = string.Format("{0}.{1}",
            string.Format("{1}_{0}", Guid.NewGuid(), fu.FileName.Substring(0, poz)).ToURL(),
            uzanti);
                Path = string.Format("~/upload/sektorler/{0}/{1}/{2}/", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                if (!Directory.Exists(Server.MapPath(Path)))
                    Directory.CreateDirectory(Server.MapPath(Path));
                fu.SaveAs(Server.MapPath(Path) + FileName);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bir hata oluştu!", MessageBox.MesajTipleri.Error);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        imgSektor.ToolTip = Path + FileName;
        imgSektor.AlternateText = Path + FileName;
        imgSektor.ImageUrl = Path + FileName;
        divFotografGoster.Visible = true;
        divFotoUpload.Visible = false;
    }

    protected void btnSil_Click(object sender, ImageClickEventArgs e)
    {
        DosyaDB dosyaDB = new DosyaDB();
        dosyaDB.ResimSil(Path + FileName);
        divFotoUpload.Visible = true;
        divFotografGoster.Visible = false;
        MessageBox.Show("Fotoğraf silindi!", MessageBox.MesajTipleri.Success);
    }

    protected void btnKayitKaydet_Click(object sender, EventArgs e)
    {
        var baslik = txtKayitBaslik.Text.ToTemizMetin();
        var oncelik = txtKayitOncelik.Text.ToInt32();
        var aciklama = ceKayitAciklama.Text;

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
                sektorler sektor = null;
                if (SektorKayitId == 0)
                {
                    sektor = new sektorler
                    {
                        Baslik = baslik,
                        Oncelik = oncelik,
                        Goster = cbKayitGoster.Checked,
                        DilKod = DilKod,
                        Aciklama = aciklama,
                        Fotograf = (Path + FileName).Substring(1)
                    };
                    db.sektorler.Add(sektor);
                    MessageBox.Show("Yeni sektör başarıyla eklendi!", MessageBox.MesajTipleri.Success);
                }
                else
                {
                    sektor = db.sektorler.FirstOrDefault(x => x.Id == SektorKayitId);
                    sektor.Baslik = baslik;
                    sektor.Goster = cbKayitGoster.Checked;
                    sektor.Oncelik = oncelik;
                    sektor.Aciklama = aciklama;
                    sektor.Fotograf = imgSektor.ImageUrl.Substring(1);
                    MessageBox.Show("Sektör başarıyla güncellendi!", MessageBox.MesajTipleri.Success);
                }
                db.SaveChanges();
                pnlKayit.Style["display"] = "none";
                KayitlariGetir();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bir hata oluştu!", MessageBox.MesajTipleri.Success);
        }
    }

    protected void gvKayitlar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            var kayit = e.Row.DataItem as Info.SektorInfo;
            Literal ltlDil = e.Row.FindControl("ltlDil") as Literal;
            Literal ltlGoster = e.Row.FindControl("ltlGoster") as Literal;
            ltlGoster.Text = (kayit.Goster) ? "<i class='far fa-thumbs-up'></i>" : "<i class='far fa-thumbs-down'></i>";
            ltlDil.Text = (kayit.DilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"">" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English"">";
        }
    }
}