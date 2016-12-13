using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BitBookMvcApp.Models;
using BitBookMvcApp.Models.ViewModels.Registration;

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

        public ActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            BitBookMvcAppDbContext db = new BitBookMvcAppDbContext();
            if (ModelState.IsValid)
            {
                int userId = (int) Session["UserId"];
                Models.User user = db.Users.Find(userId);
                if (user.Password==changePassword.OldPassword)
                {
                    user.Password = changePassword.NewPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Logout");
                }
            }
            return View();
        }
    }
}
