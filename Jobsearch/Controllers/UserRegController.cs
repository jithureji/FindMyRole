using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobsearch.Models;

namespace Jobsearch.Controllers
{
    public class UserRegController : Controller
    {
        project_mvcEntities dbobj = new project_mvcEntities();
        // GET: UserReg
        public ActionResult InsertUser_Pageload()
        {
            return View();
        }
        public ActionResult InsertUser_Click(UserInsertCls clsobj)
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
                dbobj.sp_reguser(regid, clsobj.name, clsobj.address, clsobj.state, clsobj.district, clsobj.phone, clsobj.email, clsobj.gender, clsobj.qualifiaction, clsobj.experience, clsobj.skills);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "User");
                clsobj.usermsg = "Inserted Successfull";
                return View("InsertUser_Pageload", clsobj);
            }
            return View("Insertuser_pageload", clsobj);
        }
    }
}