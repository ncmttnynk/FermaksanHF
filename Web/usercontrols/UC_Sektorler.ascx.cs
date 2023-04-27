using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_UC_Sektorler : System.Web.UI.UserControl
{
    int dilKod = 1;
    string dil = "tr";
    protected void Page_Load(object sender, EventArgs e)
    {
        dilKod = (this.Page as IPage).DilKod;
        dil = (this.Page as IPage).Dil;

        if (!IsPostBack)
        {
            ltlBaslik.Text = ((dil.Equals("tr") ? "Sektörler" : "Endustries"));
            KayitlariGetir();
        }
    }

    private void KayitlariGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var kayitlar = from x in db.sektorler
                           where x.Goster && x.DilKod == dilKod
                           orderby x.Oncelik
                           select new
                           {
                               x.Id,
                               x.Baslik,
                               x.Fotograf
                           };
            var toplam = kayitlar.Count();
            rptSektorler.DataSource = kayitlar.ToList();
            rptSektorler.DataBind();
        }
    }
}