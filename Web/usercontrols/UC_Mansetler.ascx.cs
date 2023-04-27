using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_UC_Slider : System.Web.UI.UserControl
{
    int dilKod = 1;
    string dil = "tr";
    protected void Page_PreRender(object sender, EventArgs e)
    {
        dilKod = (this.Page as IPage).DilKod;
        dil = (this.Page as IPage).Dil;
        if (!IsPostBack)
        {
            using (var db = new FermaksanEntities())
            {
                var kayitlar = from x in db.mansetler
                               where x.Goster && x.DilKod == dilKod
                               select new
                               {
                                   x.Url,
                                   x.Yeni,
                                   x.Baslik,
                                   x.Fotograf,
                                   x.Oncelik
                               };
                if (kayitlar.Count() > 0)
                {
                    rptSlider.DataSource = kayitlar.OrderBy(x => x.Oncelik).ToList();
                    rptSlider.DataBind();
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}