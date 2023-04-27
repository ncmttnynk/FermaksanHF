using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Iletisim : IPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
             {
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"},
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "İletişim" : "Contact Us")}
             };
        base.MP_Main.Title = (Dil.Equals("tr") ? "İletişim" : "Contact Us");
        base.MP_Main.H1 = (Dil.Equals("tr") ? "İletişim" : "Contact Us");
        this.Form.Action = "/" + Dil + "/Iletisim.aspx";
        if (!IsPostBack)
        {
            Session["CaptchaMetin"] = DevrimAltinkurt.DogrulamaKodu.RastgeleKodUretici();
            btnIletisimKaydet.Text = (Dil.Equals("tr") ? "Kaydet" : "Submit");
            SabitlerDB sDB = new SabitlerDB();
            ltlAdres.Text = sDB.IcerikGetir(Enums.Sabitler.Adres);
            ltlTelefon.Text = sDB.IcerikGetir(Enums.Sabitler.Telefon);
            hlMail.Text = sDB.IcerikGetir(Enums.Sabitler.EpostaTumu);
            ltlCalismaSaatleri.Text = (DilKod == 1) ? sDB.TurkceIcerikGetir(Enums.Sabitler.CalismaSaatleri) : sDB.IngilizceIcerikGetir(Enums.Sabitler.CalismaSaatleri);
        }
    }

    private void GoogleMapsHazirla(string koord)
    {
        GoogleMapForASPNet1.GoogleMapObject.APIKey = Config.GoogleMapApiKey;

        GoogleMapForASPNet1.GoogleMapObject.Width = "100%"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet1.GoogleMapObject.Height = "400px";

        double lat = 38.68551;
        double lon = 34.23339;
        int zum = 6;
        if (!string.IsNullOrEmpty(koord))
        {
            try
            {
                var split = koord.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                lat = split[0].Replace(".", ",").ToDouble();
                lon = split[1].Replace(".", ",").ToDouble();
                zum = 16;
            }
            catch (Exception)
            {
                lat = 38.68551;
                lon = 34.23339;
                zum = 6;
            }
        }
        GoogleMapForASPNet1.GoogleMapObject.ZoomLevel = zum;
        GoogleMapForASPNet1.GoogleMapObject.CenterPoint = new GooglePoint("1", lat, lon);

        GooglePoint GP2 = new GooglePoint();
        GP2.ID = "SimplePushpin";
        GP2.Latitude = lat;
        GP2.Longitude = lon;
        GP2.InfoHTML = string.Format(
    @"<p class=""text-dark""><b>{0}</b></p>
<a href=""{1}"" class=""text-primary"" target=""_blank"">{2}</a>",
    Config.Title,
    Config.SiteAdresi, Config.SiteAdresi);
        GP2.Draggable = false;
        GP2.ToolTip = Config.Title;
        GoogleMapForASPNet1.GoogleMapObject.Points.Add(GP2);
    }

    protected void btnServisKaydet_Click(object sender, EventArgs e)
    {
        var adSoyad = txtAdSoyad.Text.ToTemizMetin();
        var ePosta = txtPosta.Text.ToTemizMetin();
        var konu = txtKonu.Text.ToTemizMetin();
        var aciklama = txtAciklama.Text.ToTemizMetin();
        try
        {
            using (var db = new FermaksanEntities())
            {
                iletisim yeniMesaj = new iletisim
                {
                    Aciklama = aciklama,
                    AdSoyad = adSoyad,
                    DilKod = DilKod,
                    Eposta = ePosta,
                    Tarih = DateTime.Now,
                    Cevaplandi = false
                };
                db.iletisim.Add(yeniMesaj);
                db.SaveChanges();
                pnlIletisim.Enabled = false;
                MessageBox.Show((DilKod == 1) ? @"İletişim kaydınız alındı! </br> En kısa sürede dönüş yapılacaktır." : @"Thank you for contact request! </br> We will contact you as soon as possible.", MessageBox.MesajTipleri.Success);

            }
        }
        catch (Exception ex)
        {

        }
    }
}