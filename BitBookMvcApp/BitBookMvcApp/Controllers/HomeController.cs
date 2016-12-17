using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
        BitBookMvcAppDbContext db = new BitBookMvcAppDbContext();

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
            if (ModelState.IsValid)
            {
                int userId = (int)Session["UserId"];
                Models.User user = db.Users.Find(userId);
                if (user.Password == changePassword.OldPassword)
                {
                    user.Password = changePassword.NewPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Logout");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Post(Post post)
        {
            post.Date = DateTime.Now;
            post.IsPic = false;
            post.IsText = true;
            post.UserId = Session["UserId"] as int?;

            db.Posts.Add(post);

            SqlConnection connection = new SqlConnection();
            string query = "select distinct p.Id, p.Post, p.PicUrl,p.IsPic IsPic, p.IsText IsText, pr.ProPicId, pr.FullName,p.UserIdfrom Post pleft join FriendList f on p.UserId=f.UserIdleft join Profile pr on p.UserId=pr.UserIdwhere f.UserId=1 or f.FriendId=1";
            List<Post> posts = db.Posts.OrderByDescending(m => m.Id).ToList();
            List<Comment> comments = db.Comments.OrderByDescending(m => m.Id).ToList();
            List<Like> likes = db.Likes.OrderByDescending(m => m.Id).ToList();
            List<Profile> profiles = db.Profiles.OrderByDescending(m => m.Id).ToList();

            return PartialView("_Post");
        }

        public ActionResult PostResponse()
        {
            return null;
        }
    }
}
