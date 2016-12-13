using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BitBookMvcApp.Models;
using BitBookMvcApp.Models.ViewModels;

namespace BitBookMvcApp.Controllers
{
    public class SearchPeopleController : Controller
    {
        private BitBookMvcAppDbContext db = new BitBookMvcAppDbContext();
       
        public ActionResult Index()
        {
            var profiles = db.Profiles.Include(p => p.User);
            return View(profiles.ToList());
        }

        public PartialViewResult Search(string name)
        {
            /*string name;
            if (searchedName != null)
            {
                name = searchedName;
                Session["SearchedName"] = searchedName;
            }
            else
            {
                name = (string) Session["SearchedName"];
            }*/

            int userId = (int)Session["UserId"];
            string connectionString =
                WebConfigurationManager.ConnectionStrings["BitBookMvcAppDb"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            var query = "SELECT p.UserId, FullName, f.Id, SenderId, ReceiverId, IsAccepted, PicUrl FROM (SELECT * FROM Profile p WHERE p.FullName LIKE '%" + name + "%') p LEFT OUTER JOIN Post po ON p.ProPicId=po.Id LEFT OUTER JOIN (SELECT * FROM FriendRequest f WHERE f.SenderId=" + userId + " OR f.ReceiverId=" + userId + ") f ON p.UserId=f.SenderId OR p.UserId=f.ReceiverId";
            var command = new SqlCommand(query, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            List<SearchResult> results = new List<SearchResult>();
            while (reader.Read())
            {
                results.Add(new SearchResult
                {
                    SearchedProfileId = reader["UserId"] is DBNull ? (int?)null : Convert.ToInt32(reader["UserId"]),
                    Name = reader["FullName"] is DBNull ? null : reader["FullName"].ToString(),
                    ProPicUrl = reader["PicUrl"] is DBNull ? null : reader["PicUrl"].ToString(),
                    FriendRequestId = reader["Id"] is DBNull ? (int?)null : Convert.ToInt32(reader["Id"]),
                    SenderId = reader["SenderId"] is DBNull ? (int?)null : Convert.ToInt32(reader["SenderId"]),
                    ReceiverId = reader["ReceiverId"] is DBNull ? (int?)null : Convert.ToInt32(reader["ReceiverId"]),
                    IsAccepted = reader["IsAccepted"] is DBNull ? (bool?)null : Convert.ToBoolean(reader["IsAccepted"])
                });
            }
            reader.Close();
            connection.Close();
            return PartialView("_SearchResult", results);
        }

        [HttpPost]
        public ActionResult ResponseSearch(string searchType, int? searchUserId, int? friendRequestId)
        {
            /*int? searchUserId = Request.Form["searchUserId"] == "" ? null :(int?) Convert.ToInt32(Request.Form["searchUserId"]);
            int? friendRequestId = Request.Form["friendRequestId"] == "" ? null : (int?)Convert.ToInt32(Request.Form["friendRequestId"]);*/
            switch (searchType)
            {
                case "Add Friend":
                    return RedirectToAction("SendRequest", new { SearchedUserId = searchUserId, FriendRequestId = friendRequestId });
                case "Ignore":
                    return RedirectToAction("IgnoreRequest", new { SearchedUserId = searchUserId, FriendRequestId = friendRequestId });
                case "Unfriend":
                    return RedirectToAction("Unfriend", new { SearchedUserId = searchUserId, FriendRequestId = friendRequestId });
                case "Accept":
                    return RedirectToAction("AcceptRequest", new { SearchedUserId = searchUserId, FriendRequestId = friendRequestId });
                case "Cancel Request":
                    return RedirectToAction("CancelRequest", new { SearchedUserId = searchUserId, FriendRequestId = friendRequestId });
                default:
                    return RedirectToAction("Search");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult SendRequest(int? searchedUserId, int? friendRequestId)
        {
            int userId = (int)Session["UserId"];
            FriendRequest friendRequest = new FriendRequest()
            {
                SenderId = userId,
                ReceiverId = searchedUserId,
                IsAccepted = false
            };
            db.FriendRequests.Add(friendRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IgnoreRequest(int? searchedUserId, int? friendRequestId)
        {
            int userId = (int)Session["UserId"];
            FriendRequest friendRequest =
                db.FriendRequests.FirstOrDefault(f => f.SenderId == searchedUserId && f.ReceiverId == userId);
            db.FriendRequests.Remove(friendRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Unfriend(int? searchedUserId, int? friendRequestId)
        {
            int userId = (int)Session["UserId"];
            FriendList friend = db.FriendLists.FirstOrDefault(f => f.FriendId == userId && f.UserId == searchedUserId);
            db.FriendLists.Remove(friend);
            friend = db.FriendLists.FirstOrDefault(f => f.UserId == userId && f.FriendId == searchedUserId);
            db.FriendLists.Remove(friend);
            FriendRequest friendRequest =
                db.FriendRequests.FirstOrDefault(
                    f =>
                        (f.ReceiverId == searchedUserId && f.SenderId == userId) ||
                        (f.SenderId == searchedUserId && f.ReceiverId == userId));
            db.FriendRequests.Remove(friendRequest);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AcceptRequest(int? searchedUserId, int? friendRequestId)
        {
            int userId = (int)Session["UserId"];
            FriendList friendList = new FriendList()
            {
                FriendId = searchedUserId,
                UserId = userId
            };
            friendList = db.FriendLists.Add(friendList);
            friendList = new FriendList()
            {
                UserId = searchedUserId,
                FriendId = userId
            };
            db.FriendLists.Add(friendList);
            FriendRequest friendRequest = db.FriendRequests.Find(friendRequestId);
            friendRequest.IsAccepted = true;
            db.Entry(friendRequest).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CancelRequest(int? searchedUserId, int? friendRequestId)
        {
            int userId = (int)Session["UserId"];
            FriendRequest friendRequest =
                db.FriendRequests.FirstOrDefault(f => f.SenderId == userId && f.ReceiverId == searchedUserId);
            db.FriendRequests.Remove(friendRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}