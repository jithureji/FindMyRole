using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobsearch.Models
{
    public class CompInsertCls
    {
        [Required(ErrorMessage ="Enter company name")]
        public string cname { set; get; }
        [Required(ErrorMessage = "Enter company address")]
        public string caddress { set; get; }
        [Required(ErrorMessage = "Enter company phone")]
        public string cphone { set; get; }
        [Required(ErrorMessage = "Enter company website")]
        public string cweb { set; get; }
        public string cmsg { set; get; }
        public string cusername { set; get; }
        public string cpass { set; get; }
        [Compare("cpass", ErrorMessage = "password mismatch")]
        public string cfpass { set; get; }
    }
}