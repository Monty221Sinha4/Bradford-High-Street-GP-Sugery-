using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.SqlServer;

namespace GP_Project.Controllers.Admin
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin objuser)
        {
            if (ModelState.IsValid)
            {
                using(LoginEntities DB=new LoginEntities())
                {
                    var obj = DB.UserLogins.Where(a => a.Username.Equals(objuser.Username) && a.Password.Equals(objuser.Password)).FirstOrDefault();
                    if(obj != null)
                    {
                        Session["UserID"] = obj.UserID.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objuser);
        }
        public ActionResult Dashboard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else { return RedirectToAction("Login");
            }
        }
    }
}