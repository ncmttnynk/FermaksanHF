using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_UC_Header : System.Web.UI.UserControl
{
    int dilKod = 1;
    string dil = "tr";
    protected void Page_Load(object sender, EventArgs e)
    {
        dilKod = (this.Page as IPage).DilKod;
        dil = (this.Page as IPage).Dil;
        if (!IsPostBack)
        {
            SabitlerDB sDB = new SabitlerDB();
            //ltlIletisimBaslik.Text = (dilKod == 1) ? "Bizimle iletişime geçin!" : "Get in touch!";
            string facebook = sDB.IcerikGetir(Enums.Sabitler.Facebook);
            string youtube = sDB.IcerikGetir(Enums.Sabitler.YouTube);
            if (!string.IsNullOrEmpty(facebook))
            {
                hlFacebook.Visible = true;
                hlFacebook.NavigateUrl = facebook;
            }
            if (!string.IsNullOrEmpty(youtube))
            {
                hlYoutube.Visible = true;
                hlYoutube.NavigateUrl = youtube;
            }
            ltlIletisimTelefon.Text = sDB.IcerikGetir(Enums.Sabitler.Telefon);
            ltlIletisimEposta.Text = sDB.IcerikGetir(Enums.Sabitler.Eposta);
            ltlSeciliDil.Text = (dilKod == 1) ? @"<img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe""/>
                        Türkçe
                                                    <i class=""fas fa-angle-down""></i>" : @"<img src=""/img/blank.gif"" class=""flag flag-us"" alt=""English""/>
                        English
                                                    <i class=""fas fa-angle-down""></i>";
            ltlMenuDil.Text = (dilKod == 1) ? @"<a class=""dropdown-item"" href=""/Language.aspx?Dil=en"">
                            <img src= ""/img/blank.gif"" class=""flag flag-us"" alt=""English"" />
                            English</a>"
                         : @"<a class=""dropdown-item"" href=""/Language.aspx?Dil=tr"">
                              <img src=""/img/blank.gif"" class=""flag flag-tr"" alt=""Türkçe"" />
                            Türkçe</a>";
            ltlUstMenu.Text = (dilKod == 1) ? @"<li class=""nav-item d-none d-lg-block"">
                            <a class=""nav-link"" href=""/tr/Iletisim""><i class=""fas fa-angle-right""></i>İletişim</a>
                </li>" : @"<li class=""nav-item d-none d-lg-block"">
                            <a class=""nav-link"" href=""/en/Iletisim""><i class=""fas fa-angle-right""></i>Contact Us</a>
                </li>";
        }
    }
}