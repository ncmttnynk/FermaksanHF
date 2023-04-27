using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_IletisimTalepleri : IPage
{
    int IletisimKayitId
    {
        get { return ViewState["ILETISIMKAYITID"].ToInt32(); }
        set { ViewState["ILETISIMKAYITID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var mp = this.Master as IMP_Main;
        mp.H1 = "İletişim Mesajları";
        mp.Title = "İletişim Mesajları";
        mp.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                    new Info.BuradasinizInfo {Title="Anasayfa", Url="../admin/Anasayfa.aspx"},
                    new Info.BuradasinizInfo {Title="İletişim Mesajları"}
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
            var kayitlar = (from x in db.iletisim
                            orderby x.Id descending
                            select new Info.IletisimInfo
                            {
                                Id = x.Id,
                                AdSoyad = x.AdSoyad,
                                Aciklama = x.Aciklama,
                                Eposta = x.Eposta,
                                DilKod = x.DilKod,
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
                var kayit = db.iletisim.FirstOrDefault(x => x.Id == id);
                ltlServisAdSoyad.Text = kayit.AdSoyad;
                ltlServisAciklama.Text = kayit.Aciklama;
                ltlServisEposta.Text = kayit.Eposta;
                ltlServisTarih.Text = kayit.Tarih.ToShortDateString();
                pnlKayit.Style["display"] = "block";
                lblKayitBaslik.Text = "İletişim Kaydı Cevaplama";
                IletisimKayitId = id;
            }
        }
    }

    protected void btnKapatUst_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
        IletisimKayitId = 0;
    }

    protected void btnKayitKapat_Click(object sender, EventArgs e)
    {
        pnlKayit.Style["display"] = "none";
        IletisimKayitId = 0;
    }

    protected void btnServisCevapla_Click(object sender, EventArgs e)
    {
        try
        {
            using (var db = new FermaksanEntities())
            {
                var kayit = db.iletisim.FirstOrDefault(x => x.Id == IletisimKayitId);
                kayit.Cevaplandi = true;
                db.SaveChanges();
                pnlKayit.Style["display"] = "none";
                KayitlariGetir();

                // Mail buraya gelecek
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
            var kayit = e.Row.DataItem as Info.IletisimInfo;
            Literal ltlDil = e.Row.FindControl("ltlDil") as Literal;
            Literal ltlCevaplandi = e.Row.FindControl("ltlCevaplandi") as Literal;
            LinkButton lbCevapla = e.Row.FindControl("lbCevapla") as LinkButton;
            lbCevapla.Visible = (kayit.Cevaplandi) ? false : true;
            ltlCevaplandi.Text = (kayit.Cevaplandi) ? "<i class='far fa-thumbs-up'></i>" : "<i class='far fa-thumbs-down'></i>";
            ltlDil.Text = (kayit.DilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"">" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English"">";
        }
    }
}