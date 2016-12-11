using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitBookMvcApp.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //Session["UserId"] = null;
            return RedirectToAction("Signup", "Registration");
        }
    }
}
