using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBookMvcApp.Models;
using BitBookMvcApp.Models.ViewModels;

namespace BitBookMvcApp.Controllers
{
    public class FriendController : Controller
    {
        BitBookMvcAppDbContext db = new BitBookMvcAppDbContext();
        public ActionResult ViewAllFriend()
        {
            var userId = 1;
            List<FriendListView> friendList = (from list in db.FriendLists
                join profile in db.Profiles on list.FriendId equals profile.UserId into listProfile
                from profile in listProfile.DefaultIfEmpty()
                join post in db.Posts on profile.ProPicId equals post.Id into listProfilePost
                from post in listProfilePost.DefaultIfEmpty()
                where list.UserId == userId
                select new FriendListView()
                {
                    FriendId = list.FriendId,
                    Name = profile.FullName,
                    PicUrl= post.PicUrl
                }).ToList();

            return View(friendList);
        }
	}
}