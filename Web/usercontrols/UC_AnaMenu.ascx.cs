﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAL;

public partial class usercontrols_UC_AnaMenu : System.Web.UI.UserControl
{
    int dilKod = 1;
    string dil = "tr";
    List<anamenu> tum = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        dilKod = (this.Page as IPage).DilKod;
        dil = (this.Page as IPage).Dil;
        if (!IsPostBack)
        {
            AnaMenuDB anamenuDB = new AnaMenuDB();
            ltlAnaMenu.Text = anamenuDB.MenuGetir(dilKod);
        }
    }
}