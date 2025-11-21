using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobsearch.Models;

namespace Jobsearch.Controllers
{
    public class UserLoginController : Controller
    {
        project_mvcEntities dbobj = new project_mvcEntities();
        // GET: UserLogin
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(LoginCls clsobj)
        {
            if (ModelState.IsValid)
            {
                var c = dbobj.sp_countid(clsobj.Uname, clsobj.password).FirstOrDefault();
                int cn = Convert.ToInt32(c);

                if (cn >= 1)
                {
                    var i = dbobj.sp_regid(clsobj.Uname, clsobj.password).FirstOrDefault();
                    int uid = Convert.ToInt32(i);
                    Session["uid"] = uid;

                    var lt = dbobj.sp_logintype(clsobj.Uname, clsobj.password).FirstOrDefault();

                    if (!string.IsNullOrEmpty(lt) && lt.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        return RedirectToAction("AdminHome");
                    }
                    else
                    {
                        return RedirectToAction("Jobview_Pageload", "JobView");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.msg = "Invalid username and password";
                    return View("Login_Pageload", clsobj);
                }
            }

            return View("Login_Pageload", clsobj);
        }
    }
}