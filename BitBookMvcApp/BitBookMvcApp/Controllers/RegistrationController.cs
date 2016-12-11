using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BitBookMvcApp.ViewModels.Registration;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Controllers
{
    public class RegistrationController : Controller
    {
        private BitBookMvcAppDbContext db = new BitBookMvcAppDbContext();


        public ActionResult Index()
        {
            
            return View(db.Profiles.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        
        public ActionResult Signup()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            Session["Days"] = DaysDropDown();
            Session["Months"] = MonthDropDown();
            Session["Years"] = YearList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "Id, FirstName, LastName, Email, Password, ConfirmPassword, Gender, day, month, year")]RegistrationAndLogin registrationandlogin, Registration registration, string day, string month, string year)
        {
            Profile profile = new Profile
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                FullName = registration.FirstName + " " + registration.LastName,
                Gender = registration.Gender,
                DOB = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day)),
                HasRelationship = false,
                CreateDate = DateTime.Today
            };

            User user = new User{Email = registration.Email, Password = registration.Password};

            if (ModelState.IsValid)
            {
                User aUser = db.Users.Add(user);
                db.SaveChanges();
                profile.UserId = aUser.Id;
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            Session["Days"] = DaysDropDown();
            Session["Months"] = MonthDropDown();
            Session["Years"] = YearList();
            return View(registrationandlogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return RedirectToAction("Signup");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Id, Email, Password")]RegistrationAndLogin registrationAndLogin, Login login)
        {
            if (ModelState.IsValid)
            {
                var aUser = db.Users
                    .Join(db.Profiles, user => user.Id, profile => profile.UserId,
                        (user, profile) =>
                            new {Id = user.Id, Email = user.Email, Password = user.Password, Name = profile.FullName})
                    .FirstOrDefault(user => user.Email == login.Email && user.Password == login.Password);
                if (aUser != null)
                {
                    Session["User"] = aUser.Name;
                    Session["UserId"] = aUser.Id;
                    Session["Relationship"] = GetAllRelationship();
                    Session["FamilyRelationship"] = GetAllFamilyRelationship();
                    FormsAuthentication.SetAuthCookie(aUser.Name, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["LoginFailed"] = "Wrong username or password";
                }
            }
            return RedirectToAction("Signup");

        }
        
        public List<SelectListItem> DaysDropDown()
        {
            var days = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Days...", Value = ""}
            };

            for (int i = 1; i <= 31; i++)
            {
                var day = new SelectListItem() { Text = Convert.ToString(i), Value = Convert.ToString(i) };
                days.Add(day);
            }
            return days;
        }

        public List<SelectListItem> MonthDropDown()
        {
            var monthList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Month...", Value = ""}
            };
            var monthArray = new string[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                "November", "December"
            };

            for (int i = 1; i <= 12; i++)
            {
                var month = new SelectListItem() { Text = monthArray[i - 1], Value = Convert.ToString(i) };
                monthList.Add(month);
            }
            return monthList;
        }

        public List<SelectListItem> YearList()
        {
            var yearList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Year...", Value = ""}
            };


            for (int i = 1900; i <= DateTime.Today.Year; i++)
            {
                var year = new SelectListItem() { Text = Convert.ToString(i), Value = Convert.ToString(i) };
                yearList.Add(year);
            }
            return yearList;
        }

        private List<Relationship> GetAllRelationship()
        {
            return new List<Relationship>
            {
                new Relationship{RelationshipName = "---"},
                new Relationship{Id = 1, RelationshipName = "Single"},
                new Relationship{Id = 2, RelationshipName = "In a relationship"},
                new Relationship{Id = 2, RelationshipName = "Engaged"},
                new Relationship{Id = 2, RelationshipName = "Married"},
                new Relationship{Id = 2, RelationshipName = "In an open relationship"},
                new Relationship{Id = 2, RelationshipName = "It's complicated"},
                new Relationship{Id = 2, RelationshipName = "Separated"},
                new Relationship{Id = 2, RelationshipName = "Divorced"},
                new Relationship{Id = 2, RelationshipName = "Widowed"}
            };
        }

        private List<FamilyRelationship> GetAllFamilyRelationship()
        {
            return new List<FamilyRelationship>
            {
                new FamilyRelationship {RelationshipName = "---"},
                new FamilyRelationship {Id = 1, RelationshipName = "father"},
                new FamilyRelationship {Id = 1, RelationshipName = "mother"},
                new FamilyRelationship {Id = 1, RelationshipName = "son"},
                new FamilyRelationship {Id = 1, RelationshipName = "daughter"},
                new FamilyRelationship {Id = 1, RelationshipName = "husband"},
                new FamilyRelationship {Id = 1, RelationshipName = "wife"},
                new FamilyRelationship {Id = 1, RelationshipName = "brother"},
                new FamilyRelationship {Id = 1, RelationshipName = "sister"},
                new FamilyRelationship {Id = 1, RelationshipName = "grandfather"},
                new FamilyRelationship {Id = 1, RelationshipName = "grandmother"},
                new FamilyRelationship {Id = 1, RelationshipName = "grandson"},
                new FamilyRelationship {Id = 1, RelationshipName = "granddaughter"},
                new FamilyRelationship {Id = 1, RelationshipName = "uncle"},
                new FamilyRelationship {Id = 1, RelationshipName = "aunt"},
                new FamilyRelationship {Id = 1, RelationshipName = "nephew"},
                new FamilyRelationship {Id = 1, RelationshipName = "niece"},
                new FamilyRelationship {Id = 1, RelationshipName = "cousin"},
                new FamilyRelationship {Id = 1, RelationshipName = "cousin"},
                new FamilyRelationship {Id = 1, RelationshipName = "stepfather "},
                new FamilyRelationship {Id = 1, RelationshipName = "stepmother "},
                new FamilyRelationship {Id = 1, RelationshipName = "stepbrother "},
                new FamilyRelationship {Id = 1, RelationshipName = "stepsister "},
                new FamilyRelationship {Id = 1, RelationshipName = "stepson "},
                new FamilyRelationship {Id = 1, RelationshipName = "stepdaughter  "},
                new FamilyRelationship {Id = 1, RelationshipName = "father-in-law "},
                new FamilyRelationship {Id = 1, RelationshipName = "mother-in-law "},
                new FamilyRelationship {Id = 1, RelationshipName = "brother-in-law "},
                new FamilyRelationship {Id = 1, RelationshipName = "sister-in-law "},
                new FamilyRelationship {Id = 1, RelationshipName = "son-in-law "},
                new FamilyRelationship {Id = 1, RelationshipName = "daughter-in-law "}
            };
        }
    }
}
