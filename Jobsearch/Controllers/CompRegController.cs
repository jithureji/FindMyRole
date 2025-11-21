using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobsearch.Models;

namespace Jobsearch.Controllers
{
    public class CompRegController : Controller
    {
        project_mvcEntities dbobj = new project_mvcEntities();
        // GET: CompReg
        public ActionResult CompInsert_Pageload()
        {
            return View();
        }
        public ActionResult CompInsert_Click(CompInsertCls clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_compreg(regid, clsobj.cname, clsobj.caddress, clsobj.cphone, clsobj.cweb);
                dbobj.sp_loginsert(regid, clsobj.cusername, clsobj.cpass, "Admin");
                clsobj.cmsg = "Inserted Successfull";
                return View("CompInsert_Pageload", clsobj);
            }
            return View("CompInsert_Pageload", clsobj);
        }
    }
}