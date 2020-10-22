using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hr_Management_System.Models
{
    public class login
    {
       [Required]
        public string name { get; set; }
       [Required]

        public string password { get; set; }

    }
}