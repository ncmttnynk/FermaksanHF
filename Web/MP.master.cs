using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP : IMP_Main
{
    public string MyTitle
    {
        get
        {
            if (ViewState["TITLE"] == null) return "";
            return ViewState["TITLE"].ToString();
        }
        set { ViewState["TITLE"] = value; }
    }
    public string MyH1
    {
        get
        {
            if (ViewState["H1"] == null) return "";
            return ViewState["H1"].ToString();
        }
        set { ViewState["H1"] = value; }
    }
    public override List<BuradasinizInfo> Buradasiniz
    {
        set
        {
            UC_Buradasiniz1.Buradasiniz = value;
        }
    }
    public override string Title
    {
        set
        {
            MyTitle = value;
        }
    }
    public override string H1
    {
        set
        {
            MyH1 = value;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!MyTitle.IsNullOrEmpty())
        {
            Page.Title = MyTitle + " | " + Config.Title;
        }
        else
            Page.Title = Config.Title;

    }

    public void Page_Load(object sender, EventArgs e)
    {
        form1.Action = Request.RawUrl;
    }
}
