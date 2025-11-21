using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobsearch.Models
{
    public class JobApplication
    {
        public int Job_id { set; get; }
        public int Company_id { set; get; }
        public int user_id { set; get; }
        public string Resume { set; get; }
        public DateTime App_Date { set; get; }
        public int status { set; get; }
    }
}