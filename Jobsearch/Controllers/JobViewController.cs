using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobsearch.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Jobsearch.Controllers
{
    public class JobViewController : Controller
    {
        project_mvcEntities dbobj = new project_mvcEntities();

        // GET: JobView
        public ActionResult Jobview_Pageload()
        {
            return View(GetJobList());
        }

        // Load all jobs
        private JobSearch GetJobList()
        {
            var joblists = new JobSearch();

            // Call the stored procedure
            var jobs = dbobj.sp_jobpost().ToList();

            foreach (var j in jobs)
            {
                var jobobj = new jobList
                {
                    Job_id = j.Job_Id,       
                    Company_id = j.Comp_id,
                    Job_role = j.Job_role,
                    skill = j.Skills,
                    exp = j.Experience,
                    jobstatus = j.JobStatus,
                    date = j.Last_date,
                    loca = j.Location,
                    sala = Convert.ToInt32(j.Salary)
                };

                joblists.selectjob.Add(jobobj);
            }

            return joblists;
        }

        // POST: Search jobs
        [HttpPost]
        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";

            if (!string.IsNullOrWhiteSpace(clsobj.interse.exp))
                qry += " AND Experience LIKE '%" + clsobj.interse.exp + "%'";

            if (!string.IsNullOrWhiteSpace(clsobj.interse.skill))
                qry += " AND Skills LIKE '%" + clsobj.interse.skill + "%'";

            if (!string.IsNullOrWhiteSpace(clsobj.interse.loca))
                qry += " AND Location LIKE '%" + clsobj.interse.loca + "%'";

            return View("Jobview_Pageload", GetFilteredJobs(qry));
        }

        // Load filtered jobs from SP_Jobsearches
        private JobSearch GetFilteredJobs(string qry)
        {
            var joblist = new JobSearch();

            using (var con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["importantdataconnection"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SP_Jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var jobcls = new jobList
                    {
                        Job_id = Convert.ToInt32(dr["Job_Id"]),
                        Company_id = Convert.ToInt32(dr["Comp_id"]),
                        Job_role = dr["Job_role"].ToString(),
                        skill = dr["Skills"].ToString(),
                        exp = dr["Experience"].ToString(),
                        jobstatus = dr["JobStatus"].ToString(),
                        date = Convert.ToDateTime(dr["Last_date"]),
                        loca = dr["Location"].ToString(),
                        sala = Convert.ToInt32(dr["Salary"])
                    };

                    joblist.selectjob.Add(jobcls);
                }

                con.Close();
            }

            return joblist;
        }
    }
}
