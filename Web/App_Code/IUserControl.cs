﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IUserControl
/// </summary>
public class IUserControl : System.Web.UI.UserControl
{
    public IPage PageAna
    {
        get
        {
            return this.Page as IPage;
        }
    }
    public IUserControl()
    {
        
    }
}