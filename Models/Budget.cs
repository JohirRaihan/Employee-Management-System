//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hr_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Budget
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Cost required")]

        public string Cost { get; set; }
        [Required(ErrorMessage = "Purpose required")]

        public string Purpose { get; set; }

        public string Details { get; set; }
        [Required(ErrorMessage = "Total required")]

        public string Total { get; set; }
        [Required(ErrorMessage = "Date required")]

        public Nullable<System.DateTime> IssuDate { get; set; }
    }
}
