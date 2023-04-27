using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AnaMenuDB
{
    string menuStr = "";
    int derinlik = 0;
    List<anamenu> menuler = null;

    public List<anamenu> AnaMenuGetir()
    {
        using (var db = new FermaksanEntities())
        {
            var tumu = db.anamenu.Where(x => x.Goster).ToList();
            return tumu;
        }
    }

    public string MenuGetir(int dilKod)
    {
        if (HttpContext.Current.Cache["ANAMENU"] != null)
        {
            menuStr = (string)HttpContext.Current.Cache["ANAMENU"];
        }
        else
        {
            using (var db = new FermaksanEntities())
            {
                menuler = db.anamenu.ToList();
            }
            var ana = menuler.Where(x => x.UstMenuId == 0 && x.DilKod == dilKod).OrderBy(x => x.Oncelik).ToList();
            AgacOlustur(ana);
        }
        return menuStr;
    }

    private void AgacOlustur(List<anamenu> ana)
    {
        derinlik++;
        if (derinlik == 1)
            menuStr += @"<nav class=""collapse""><ul class=""nav nav-pills"" id=""mainNav"">";
        else
            menuStr += @"<ul class=""dropdown-menu "">";

        foreach (var a in ana)
        {
            var alt = menuler.Where(x => x.UstMenuId == a.Id).OrderBy(x => x.Oncelik).ToList();

            if (derinlik == 1)
            {
                menuStr += string.Format(@"<li class=""{4}""> <a class=""{3}"" href=""{0}"">{1} {2} </a>", a.Url, a.Baslik, alt.Count > 0 ? "" : "", alt.Count > 0 ? "dropdown-item dropdown-toggle " : "", alt.Count > 0 ? "dropdown" : "");
            }
            else
                menuStr +=
                    string.Format(@"<li{0}><a class=""dropdown-item"" href=""{1}"">{2}</a>",
                        alt.Count > 0 ? @" class=""dropdown-submenu""" : "",
                        a.Url, a.Baslik);

            if (alt.Count > 0) AgacOlustur(alt);

            menuStr += @"</li>";
        }
        if (derinlik == 1)
            menuStr += @"</ul></nav>";
        else
            menuStr += @"</ul>";
        derinlik--;
    }
}
