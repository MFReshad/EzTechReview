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

        //public string ConString = @"data source=122O144O163HI\SQLEXPRESS;initial catalog=Eztechreview;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        public string ConString = @"data source=122O144O163HI\SQLEXPRESS;initial catalog=Eztechreview;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;";

        //data source=122O144O163HI\SQLEXPRESS;initial catalog=Eztechreview;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
        //<add name="EztechreviewEntitiess" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=122O144O163HI\SQLEXPRESS;initial catalog=Eztechreview;user id=rd;password=1234;MultipleActiveResultSets=True;App=EntityFramework&quot;"
    }
}