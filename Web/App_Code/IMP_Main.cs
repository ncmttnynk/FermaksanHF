using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public abstract class IMP_Main : System.Web.UI.MasterPage
{
    public abstract string Title { set; }
    public abstract string H1 { set; }
    public abstract List<BuradasinizInfo> Buradasiniz { set; }

}
