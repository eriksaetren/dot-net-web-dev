using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanSimplyByCJ.Models
{
    public class EmailForm
    {
        [Display(Name = "Your Name:")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Your Email:")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string message { get; set; }


    }
}