using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            List<FriendListView> friendList =
                (from list in db.FriendLists
                 join profile in db.Profiles on list.FriendId equals profile.UserId into listProfile
                 from profile in listProfile.DefaultIfEmpty()
                 join post in db.Posts on profile.ProPicId equals post.Id into listProfilePost
                 from post in listProfilePost.DefaultIfEmpty()
                 where list.UserId == userId
                 select new FriendListView()
                 {
                     FriendId = list.FriendId,
                     Name = profile.FullName,
                     PicUrl = post.PicUrl
                 }).ToList();

            return View(friendList);
        }

        public ActionResult ViewFriendRequests()
        {
            var userId = 1;
            List<FriendListView> friendRequestList =
                (from list in db.FriendRequests
                 join profile in db.Profiles on list.SenderId equals profile.UserId into listProfile
                 from profile in listProfile.DefaultIfEmpty()
                 join post in db.Posts on profile.ProPicId equals post.Id into listProfilePost
                 from post in listProfilePost.DefaultIfEmpty()
                 where list.ReceiverId == userId && list.IsAccepted==false
                 select new FriendListView()
                 {
                     FriendId = list.SenderId,
                     Name = profile.FullName,
                     PicUrl = post.PicUrl
                 }).ToList();


            return View(friendRequestList);
        }

        public ActionResult ResponseRequest(string responseType, int? friendId)
        {
            switch (responseType)
            {
                case "Accept":
                    return RedirectToAction("AcceptRequest", new{FriendId=friendId});
                default:
                    return RedirectToAction("IgnoreRequest", new { FriendId = friendId });
            }
        }

        public ActionResult IgnoreRequest(int? friendId)
        {
            int userId = (int)Session["UserId"];
            FriendRequest friendRequest =
                db.FriendRequests.FirstOrDefault(f => f.SenderId == friendId && f.ReceiverId == userId);
            db.FriendRequests.Remove(friendRequest);
            db.SaveChanges();
            return RedirectToAction("ViewFriendRequests");
        }

        public ActionResult Unfriend(int? friendId)
        {
            int userId = (int)Session["UserId"];
            FriendList friend = db.FriendLists.FirstOrDefault(f => f.FriendId == userId && f.UserId == friendId);
            db.FriendLists.Remove(friend);
            friend = db.FriendLists.FirstOrDefault(f => f.UserId == userId && f.FriendId == friendId);
            db.FriendLists.Remove(friend);
            FriendRequest friendRequest =
                db.FriendRequests.FirstOrDefault(
                    f =>
                        (f.ReceiverId == friendId && f.SenderId == userId) ||
                        (f.SenderId == friendId && f.ReceiverId == userId));
            db.FriendRequests.Remove(friendRequest);
            db.SaveChanges();

            return RedirectToAction("ViewAllFriend");
        }

        public ActionResult AcceptRequest(int? friendId)
        {
            int userId = (int)Session["UserId"];
            FriendList friendList = new FriendList()
            {
                FriendId = friendId,
                UserId = userId
            };
            friendList = db.FriendLists.Add(friendList);
            friendList = new FriendList()
            {
                UserId = friendId,
                FriendId = userId
            };
            db.FriendLists.Add(friendList);
            FriendRequest friendRequest = db.FriendRequests.FirstOrDefault(f=>f.SenderId==friendId && f.ReceiverId==userId);
            friendRequest.IsAccepted = true;
            db.Entry(friendRequest).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ViewFriendRequests");
        }
    }
}