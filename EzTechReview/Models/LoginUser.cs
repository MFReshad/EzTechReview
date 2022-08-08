using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace EzTechReview.Models
{
    public class LoginUser
    { 
        [Required]
        [Display(Name = " Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }


        [Required]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Password Not Matched")]
        public string UserPassword { get; set; }

        public string ConString = @"data source=122O144O163HI\SQLEXPRESS;initial catalog=Eztechreview;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
    }
}