using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobsearch.Models
{
    public class JobInsertCls
    {
        [Required(ErrorMessage ="Enter Job role")]
        public string jobrole { set; get; }
        [Required(ErrorMessage ="Enter the skills")]
        public string skills { set; get; }
        [Required(ErrorMessage = "Enter the experience")]
        public string exper { set; get; }
        public DateTime ldate { set; get; }
        public string location { set; get; }
        public int salary { set; get; }
        public string msg { set; get; }
    }
}