using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
    public class ListContext : DbContext
    {
        public ListContext() :
           base("DefaultConnection")
        { }
        public DbSet<List> Lists { get; set; }
    }
}