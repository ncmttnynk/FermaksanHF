using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class CMS : IPage
{
    string menuStr = "";
    string kod = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        kod = Request.QueryString["Kod"];
        if (!IsPostBack)
        {
            using (var db = new FermaksanEntities())
            {
                var sayfa = db.cms.FirstOrDefault(x => x.Kod == kod && x.DilKod == DilKod);
                if (sayfa == null)
                    Response.Redirect("/", true);
                base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
                {
                     new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"},
                     new Info.BuradasinizInfo {Title=sayfa.Baslik}
                };
                base.MP_Main.Title = sayfa.Baslik;
                //base.MP_Child.Baslik = sayfa.Baslik;
                ltlIcerik.Text = sayfa.Ayrinti;
                ltlCmsMenu.Text = MenuGetir(sayfa.AnaBaslikId);
            }
        }
    }
    int derinlik = 0;
    List<cms> menuler = null;

    public List<cms> AnaMenuGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var tumu = db.cms.Where(x => x.Goster).ToList();
            return tumu;
        }
    }

    public string MenuGetir(int SayfaId)
    {
        using (var db = new FermaksanEntities())
        {
            menuler = db.cms.ToList();
        }
        var ana = menuler.Where(x => x.BaslikId == 0 && x.Id == SayfaId && x.DilKod == DilKod).OrderBy(x => x.Oncelik).ToList();
        AgacOlustur(ana);
        return menuStr;
    }

    private void AgacOlustur(List<cms> ana)
    {
        derinlik++;
        if (derinlik == 1)
            menuStr += @"<ul class=""nav nav-list flex-column narrow"">";
        else
            menuStr += @"<ul class=""nav nav-list flex-column narrow"">";

        foreach (var a in ana)
        {
            var alt = menuler.Where(x => x.BaslikId == a.Id).OrderBy(x => x.Oncelik).ToList();
            if (derinlik == 1)
                menuStr += string.Format(@"<li class=""nav-item""><a class=""nav-link text-color-primary"" href=""{0},content"">{1}</a>", a.Kod, a.Baslik);
            else
                menuStr +=
                    string.Format(@"<li class=""nav-item""><a class=""nav-link text-color-dark"" href=""{0},content"">{1}</a>", a.Kod, a.Baslik);
            if (alt.Count > 0) AgacOlustur(alt);
            menuStr += @"</li>";
        }
        if (derinlik == 1)
            menuStr += @"</ul>";
        else
            menuStr += @"</ul>";
        derinlik--;
    }
}