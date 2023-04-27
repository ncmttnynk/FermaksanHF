using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ServisTalepleri : IPage
{
    int ServisKayitId
    {
        get { return ViewState["SERVISKAYITID"].ToInt32(); }
        set { ViewState["SERVISKAYITID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var mp = this.Master as IMP_Main;
        mp.H1 = "Servis Talep Mesajları";
        mp.Title = "Servis Talep Mesajları";
        mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="Servis Talep Mesajları"}
                };
        NYEditor ny = new NYEditor();
        ny.StandartAyarlar(ceServisCevap);
        if (!IsPostBack)
        {
            KayitlariGetir();
        }
    }

    private void KayitlariGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kayitlar = (from x in db.servis
                            orderby x.Id descending
                            select new Info.ServisInfo
                            {
                                Id = x.Id,
                                AdSoyad = x.AdSoyad,
                                Aciklama = x.Aciklama,
                                Eposta = x.Eposta,
                                DilKod = x.DilKod,
                                Telefon = x.Telefon,
                                Tarih = x.Tarih,
                                Cevaplandi = x.Cevaplandi
                            });
            var toplam = kayitlar.Count();
            UC_Sayfalama1.Toplam = toplam;
            UC_Sayfalama1.Adet = 5;
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
        if (e.CommandName.Equals("Cevapla"))
        {
            using (var db = new FermaksanEntities())
            {
                var kayit = db.servis.FirstOrDefault(x => x.Id == id);
                ltlServisAdSoyad.Text = kayit.AdSoyad;
                ltlServisAciklama.Text = kayit.Aciklama;
                ltlServisEposta.Text = kayit.Eposta;
                ltlServisTarih.Text = kayit.Tarih.ToShortDateString();
                ltlServisTelefon.Text = kayit.Telefon;
                pnlKayit.Style["display"] = "block";
                lblKayitBaslik.Text = "Servis Kaydı Cevaplama";
                ServisKayitId = id;
            }
        }
    }

    protected void btnKapatUst_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
        ServisKayitId = 0;
    }

    protected void btnKayitKapat_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
        ServisKayitId = 0;
    }

    protected void btnServisCevapla_Click(object sender, EventArgs e)
    {
        try
        {
            using (var db = new FermaksanEntities())
            {
                var kayit = db.servis.FirstOrDefault(x => x.Id == ServisKayitId);
                kayit.Cevaplandi = true;
                db.SaveChanges();
                pnlKayit.Style["display"] = "none";
                KayitlariGetir();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvKayitlar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            var kayit = e.Row.DataItem as Info.ServisInfo;
            Literal ltlDil = e.Row.FindControl("ltlDil") as Literal;
            Literal ltlCevaplandi = e.Row.FindControl("ltlCevaplandi") as Literal;
            LinkButton lbCevapla = e.Row.FindControl("lbCevapla") as LinkButton;
            lbCevapla.Visible = (kayit.Cevaplandi) ? false : true;
            ltlCevaplandi.Text = (kayit.Cevaplandi) ? "<i class='far fa-thumbs-up'></i>" : "<i class='far fa-thumbs-down'></i>";
            ltlDil.Text = (kayit.DilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"">" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English"">";
        }
    }
}