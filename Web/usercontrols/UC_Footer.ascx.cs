using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_UC_Footer : System.Web.UI.UserControl
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
            ltlFooterSol.Text = (dilKod == 1) ? (sDB.TurkceIcerikGetir(Enums.Sabitler.FooterSol)) : (sDB.IngilizceIcerikGetir(Enums.Sabitler.FooterSol));
            ltlFooterSag.Text = (dilKod == 1) ? (sDB.TurkceIcerikGetir(Enums.Sabitler.FooterSag)) : (sDB.IngilizceIcerikGetir(Enums.Sabitler.FooterSag));
            ltlFooterAlt.Text = (dilKod == 1) ? (sDB.TurkceIcerikGetir(Enums.Sabitler.FooterAlt)) : (sDB.IngilizceIcerikGetir(Enums.Sabitler.FooterAlt));

        }
    }
}