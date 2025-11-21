using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobsearch.Models
{
    public class UserInsertCls
    {
        [Required(ErrorMessage = "Enter the name")]
        public string name { set; get; }
        [Required(ErrorMessage = "Enter the address")]
        public string address { set; get; }
        [Required(ErrorMessage = "Enter the state")]
        public string state { set; get; }
        [Required(ErrorMessage = "Enter the district")]
        public string district { set; get; }
        public string phone { set; get; }
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string email { set; get; }
        public string gender { set; get; }
        public string qualifiaction { set; get; }
        public string experience { set; get; }
        public string skills { set; get; }
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpass { set; get; }
        public string usermsg { set; get; }
    }
}