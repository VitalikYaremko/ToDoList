﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace WebApplication2.Models
{
    public class AppRole : IdentityRole 
    {
        public AppRole() : base() { }

        public AppRole(string name)
            : base(name)
        { }
    }
}