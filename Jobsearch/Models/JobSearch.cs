using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobsearch.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jobList>();
            interse = new jobList();
        }
        public jobList interse { set; get; }
        public List<jobList> selectjob { set; get; }
    }
    public class jobList
    {
        public int Job_id { set; get; }
        public int Company_id { set; get; }
        public string Job_role { set; get; }
        public string skill { set; get; }
        public string exp { set; get; }
        public string jobstatus { set; get; }
        public DateTime date { set; get; }
        public string loca { set; get; }
        public int sala { set; get; }
    }
}