using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Web;

public static class MyDbFunction 
{
    [DbFunction("FermaksanModel.Store","Rastgele")]
    public static int Rastgele()
    {
        throw new ArgumentNullException();
    }
}