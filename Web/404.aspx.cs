using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _404 : IPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
             {
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"},
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Aradığınız sayfa bulunamadı!" : "The page you were looking for doesn't exist!")}
             };
        //base.MP_Main.Title = (Dil.Equals("tr") ? "Anasayfa" : "Home");
        base.MP_Main.H1 = (Dil.Equals("tr") ? "Aradığınız sayfa bulunamadı!" : "The page you were looking for doesn't exist!");
        ltlBulunamadi.Text = (Dil.Equals("tr") ? "Üzgünüz! Aradığınız sayfa bulunamadı." : "We're sorry, but the page you were looking for doesn't exist.");
        ltlLinkBaslik.Text = (Dil.Equals("tr") ? "Yardımcı bazı linkler" : "Here are some useful links.");
    }
}