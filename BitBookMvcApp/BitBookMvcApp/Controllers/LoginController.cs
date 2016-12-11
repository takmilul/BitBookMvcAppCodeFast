using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBookMvcApp.Core.BLL;
using BitBookMvcApp.Models;
using BitBookMvcApp.ViewModels.Registration;

namespace BitBookMvcApp.Controllers
{
    public class LoginController : Controller
    {
        LoginManager _loginManager = new LoginManager();
        UserManager _userManager = new UserManager();

        public RedirectResult Login(RegistrationAndLogin registrationAndLogin)
        {
            User user = new User()
            {
                Email = registrationAndLogin.Login.EmailForLogin,
                Password = registrationAndLogin.Login.PasswordForLogin
            };

            if (_loginManager.isValidUser(user))
            {
                Session["UserId"] = _userManager.GetUserByEmail(user.Email).Id;
                Session["User"] = user;
                Session["Message"] = null;
                return Redirect("/NewsFeed/Index");
            }
            else
            {
                Session["Message"] = "Wrong username or password";
                return Redirect("/Registration/SaveUser");
            }
        }

        public JsonResult UserAuthentication(RegistrationAndLogin registrationAndLogin)
        {
            var user = new User()
            {
                Email = registrationAndLogin.Login.EmailForLogin,
                Password = registrationAndLogin.Login.PasswordForLogin
            };
            if (_loginManager.isValidUser(user))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public RedirectToRouteResult Logout()
        {
            Session["User"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("SaveUser", "Registration");
            //            return Redirect("../Registration/SaveUser");
        }
    }
}