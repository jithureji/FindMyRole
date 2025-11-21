using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobsearch.Models;

namespace Jobsearch.Controllers
{
    public class InsertJobController : Controller
    {
        project_mvcEntities dbobj = new project_mvcEntities();
        // GET: InsertJob
        public ActionResult JobInsert_Pageload()
        {
            return View();
        }
        public ActionResult JobInsert_Click(JobInsertCls clsobj)
        {
            if (ModelState.IsValid)
            {
                int cmid = Convert.ToInt32(Session["uid"]);
                dbobj.sp_insertjob(cmid, clsobj.jobrole, clsobj.skills, clsobj.exper, "Available", clsobj.ldate, clsobj.location, clsobj.salary);
                clsobj.msg = "Inserted";
                return View("JobInsert_Pageload");
            }
            return View("JobInsert_Pageload");
        }
    }
}