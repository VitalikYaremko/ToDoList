using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }

    public class ListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameList { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

    }

    public class AdminModel
    {
        // public int id { get; set; }
    }
    public class Main
    {

    }

}
