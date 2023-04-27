using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Servis : IPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
             {
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"+Dil+"/Default.aspx"},
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Servis" : "Service")}
             };
        base.MP_Main.Title = (Dil.Equals("tr") ? "Servis" : "Service");
        base.MP_Main.H1 = (Dil.Equals("tr") ? "Servis" : "Service");
        this.Form.Action = "/" + Dil + "/Servis.aspx";

        if (!IsPostBack)
        {
            Session["CaptchaMetin"] = DevrimAltinkurt.DogrulamaKodu.RastgeleKodUretici();
            btnServisKaydet.Text = (Dil.Equals("tr") ? "Kaydet" : "Submit");
        }
    }

    protected void btnServisKaydet_Click(object sender, EventArgs e)
    {
        divCaptcha.Visible = false;
        if (!Session["CaptchaMetin"].ToString().Equals(txtCaptcha.Text))
        {
            txtCaptcha.Text = "";
            Session["CaptchaMetin"] = DevrimAltinkurt.DogrulamaKodu.RastgeleKodUretici();
            divCaptcha.Visible = true;
            txtCaptcha.Focus();
            return;
        }
        Session["CaptchaMetin"] = DevrimAltinkurt.DogrulamaKodu.RastgeleKodUretici();

        var adSoyad = txtServisAdSoyad.Text;
        var telefon = txtServisTelefon.Text;
        var ePosta = txtServisEposta.Text;
        var aciklama = txtServisAciklama.Text;

        try
        {
            using (var db = new FermaksanEntities())
            {
                servis yeniTalep = new servis
                {
                    Aciklama = aciklama,
                    AdSoyad = adSoyad,
                    DilKod = DilKod,
                    Eposta = ePosta,
                    Tarih = DateTime.Now,
                    Telefon = telefon,
                    Cevaplandi = false
                };
                db.servis.Add(yeniTalep);
                db.SaveChanges();
                pnlServis.Enabled = false;
                MessageBox.Show((DilKod == 1) ? @"Servis kaydınız tarafımıza ulaştı. </br> En kısa sürede dönüş yapılacaktır." : @"Thank you for sending the request! </br> We will contact you as soon as possible.", MessageBox.MesajTipleri.Success);

            }
        }
        catch (Exception ex)
        {

        }
    }
}