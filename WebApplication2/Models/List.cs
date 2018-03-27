using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebApplication2.Models
{
    public class List 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameList { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}