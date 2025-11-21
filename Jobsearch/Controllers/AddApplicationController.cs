using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobsearch.Models;

namespace Jobsearch.Controllers
{
    public class AddApplicationController : Controller
    {
        project_mvcEntities dbobj = new project_mvcEntities();

        // GET: AddApplication
        public ActionResult App_Load(int jid, int cid)
        {
            // Save IDs in Session instead of TempData
            Session["cid"] = cid;
            Session["Jid"] = jid;

            ObjectParameter op = new ObjectParameter("status", typeof(int));
            int userid = Convert.ToInt32(Session["uid"]);
            int jobid = Convert.ToInt32(Session["Jid"]);

            // Pass the output parameter to the stored procedure
            var result = dbobj.Database.SqlQuery<int>(
        "EXEC SP_CountUserAppliedJobWithId @uid = {0}, @cid = {1}",
        userid, jid
    ).FirstOrDefault();

            if (result >= 1)
            {
                ViewBag.isapplied = true;
            }

            return View(getdata());
        }

        public ActionResult App_Click(HttpPostedFileBase file, JobApplication clsobj)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Appresume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    clsobj.Resume = Path.Combine("~/Appresume", fname);
                }

                clsobj.App_Date = DateTime.Today;
                clsobj.user_id = Convert.ToInt32(Session["uid"]);
                clsobj.Company_id = Convert.ToInt32(Session["cid"]);
                clsobj.Job_id = Convert.ToInt32(Session["jid"]);

                dbobj.sp_postapplication(clsobj.user_id, clsobj.Company_id, clsobj.Job_id, clsobj.Resume, clsobj.App_Date);

                // Set a success message
                ViewBag.Message = "Your application has been submitted successfully!";

                // Return the same view with the job details
                return View("App_Load", getdata());
            }
            else
            {
                return View("App_Load", clsobj);
            }
        }


        private JobApplication getdata()
        {
            var obj = new JobApplication();

            // Fetch Job and Company IDs from Session
            if (Session["cid"] != null)
                obj.Company_id = Convert.ToInt32(Session["cid"]);

            if (Session["Jid"] != null)
                obj.Job_id = Convert.ToInt32(Session["Jid"]);

            // Set the user id from the session if available
            if (Session["uid"] != null)
                obj.user_id = Convert.ToInt32(Session["uid"]);

            // Set the current application date
            obj.App_Date = DateTime.Today;

            return obj;
        }
    }
}
