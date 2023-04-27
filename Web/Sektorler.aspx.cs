using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sektorler : IPage
{
    int sektorId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        sektorId = Request.QueryString["Id"].ToInt32();
        if (!IsPostBack)
        {
            if (sektorId > 0)
            {
                pnlSektor.Visible = true;
                hlTumSol.NavigateUrl = hlTumSag.NavigateUrl = "/" + Dil + "/Sektorler.aspx";
                using (var db = new FermaksanEntities())
                {
                    var sektorMakineler = (from x in db.makineler
                                           join t in db.s2m on x.Id equals t.MakineId
                                           where x.Goster && x.DilKod == DilKod && t.SektorId == sektorId
                                           orderby x.Oncelik
                                           let makineFoto = (from r in db.makinefotograflar
                                                           where r.MakineId == x.Id
                                                           select r).FirstOrDefault()
                                           select new
                                           {
                                               x.Baslik,
                                               x.Kod,
                                               x.Id,
                                               Fotograf = (makineFoto == null) ? "/img/projects/project.jpg" : makineFoto.Fotograf
                                           }).ToList();
                    if (sektorMakineler.Count > 0)
                    {
                        divIlgiliMakineler.Visible = true;
                        rptSektorMakineler.DataSource = sektorMakineler;
                        rptSektorMakineler.DataBind();
                    }
                    var sektor = db.sektorler.FirstOrDefault(x => x.Id == sektorId);
                    ltlSektorUstBaslik.Text = sektor.Baslik;
                    ltlSektorAciklama.Text = sektor.Aciklama;
                    img.AlternateText = sektor.Baslik;
                    img.ToolTip = sektor.Baslik;
                    if (!sektor.Fotograf.IsNullOrEmpty())
                    {
                        img.ImageUrl = sektor.Fotograf;
                        img.AlternateText = sektor.Baslik;

                    }
                    base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
                      {
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"+Dil+"/Default.aspx"},
                              new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Sektörler" : "Endustries"),Url="/"+Dil+"/Sektorler.aspx"},
                              new Info.BuradasinizInfo {Title=sektor.Baslik}
                      };
                    base.MP_Main.Title = sektor.Baslik;
                    base.MP_Main.H1 = sektor.Baslik;
                }
            }
            else
            {
                base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
             {
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"+Dil+"/Default.aspx"},
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Sektörler" : "Endustries")}
             };
                base.MP_Main.Title = (Dil.Equals("tr") ? "Sektörler" : "Endustries");
                base.MP_Main.H1 = (Dil.Equals("tr") ? "Sektörler" : "Endustries");
                UC_Sektorler1.Visible = true;
            }
        }
    }
}