using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitBookMvcApp.Models;
using BitBookMvcApp.ViewModels;

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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FirstName,LastName,FullName,DOB,Gender,ProPicId,CoverPicId,Religion,HasRelationship,RelationshipId,RelationshipWithId,About,CreateDate,UserId")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            return View(profile);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FirstName,LastName,FullName,DOB,Gender,ProPicId,CoverPicId,Religion,HasRelationship,RelationshipId,RelationshipWithId,About,CreateDate,UserId")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", profile.UserId);
            return View(profile);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public PartialViewResult Search()
        {
            string name = Request.Form["Name"];
            IQueryable<SearchResult> searchReasult = db.Profiles
                .GroupJoin(db.FriendRequests, profile => new { SenderId = profile.UserId, ReceiverId = profile.UserId }, fList => new { SenderId = fList.SenderId, ReceiverId = fList.SenderId },
                (profile, fList) => new { Profile = profile, Friend = fList })
                .GroupJoin(db.Posts, profileFList => profileFList.Profile.UserId, post => post.UserId,
                (profileFList, post) => new { Profile = profileFList.Profile, Friend = profileFList.Friend, Post = post })
                .Where(all => all.Profile.FullName.Contains(name))
                .SelectMany(all => all.Friend.DefaultIfEmpty(),
                 (all, fList) =>
                 new SearchResult()
                 {
                     SearchedProfileId = all.Profile.UserId,
                     ProPicUrl = all.Post.FirstOrDefault().PicUrl,
                     Name = all.Profile.FullName,
                     SenderId = fList.SenderId,
                     ReceiverId = fList.ReceiverId,
                     IsAccepted = fList.IsAccepted
                 });

            List<SearchResult> results = new List<SearchResult>(searchReasult);
            return PartialView("_SearchResult", results);
        }

        public ActionResult ResponseSearch(int SearchedProfileId)
        {
            return null;
        }
    }
}
