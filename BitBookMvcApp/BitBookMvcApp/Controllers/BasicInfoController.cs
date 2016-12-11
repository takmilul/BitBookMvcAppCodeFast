using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBookMvcApp.Models;
using BitBookMvcApp.ViewModels;

namespace BitBookMvcApp.Controllers
{
    public class BasicInfoController : Controller
    {
        BitBookMvcAppDbContext db = new BitBookMvcAppDbContext();


        public ActionResult Index()
        {
            BasicInfo basicInfo = GetBasicInfos();
            return View(basicInfo);
        }

        /*public ActionResult AddAddress()
        {
            return RedirectToAction("Index");
        }
*/

        [HttpPost]
        public ActionResult BasicActionResult(string buttonType)
        {
            int id;
            switch (buttonType)
            {
                case "Add Address":
                    return RedirectToAction("AddAddress");
                case "Edit Address":
                    return RedirectToAction("EditAddress");
                case "Add Education":
                    return RedirectToAction("AddEducation");
                case "Edit Education":
                    id = Convert.ToInt32(Request.Form["id"]);
                    return RedirectToAction("EditEducation", new {Id=id});
                case "Add Family Member":
                    return RedirectToAction("AddFamilyMember");
                case "Edit Family Member":
                    id = Convert.ToInt32(Request.Form["id"]);
                    return RedirectToAction("EditFamilyMember", new { Id = id });
                case "Add Skills":
                    return RedirectToAction("AddSkills");
                case "Edit Skills":
                    id = Convert.ToInt32(Request.Form["id"]);
                    return RedirectToAction("EditSkills", new { Id = id });
                case "Add Experience":
                    return RedirectToAction("AddExperience");
                case "Edit Experience":
                    id = Convert.ToInt32(Request.Form["id"]);
                    return RedirectToAction("EditExperience", new { Id = id });
                case "Add Personal Information":
                    return RedirectToAction("AddPersonalInfo");
                case "Edit Personal Information":
                    return RedirectToAction("EditPersonalInfo");
                case "Add Mobile No":
                    return RedirectToAction("AddMobileNo");
                case "Edit Mobile No":
                    id = Convert.ToInt32(Request.Form["id"]);
                    return RedirectToAction("EditMobileNo", new { Id = id });
                case "Add Interest":
                    return RedirectToAction("AddInterest");
                default:
                    id = Convert.ToInt32(Request.Form["id"]);
                    return RedirectToAction("EditInterest", new { Id = id });
            }
        }


        public PartialViewResult AddAddress()
        {
            Address address = GetBasicInfos().Address;
            return PartialView("_AddAddress", address);
        }

        [HttpPost]
        public ActionResult AddAddress(Address address)
        {
            address.UserId = (int)Session["UserId"];
            Address anAddress = db.Addresses.Add(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public PartialViewResult EditAddress()
        {
            Address address = GetBasicInfos().Address;
            return PartialView("_EditAddress", address);
        }

        [HttpPost]
        public ActionResult EditAddress(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddEducation()
        {
            return PartialView("_AddEducation");
        }

        public PartialViewResult EditEducation(int id)
        {
            Education education = db.Educations.Find(id);
            return PartialView("_EditEducation", education);

        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            education.UserId = (int)Session["UserId"];
            if (education.Degree != null)
            {
                education.HasDegree = true;
            }
            else
            {
                education.HasDegree = false;
            }
            Education anEducation = db.Educations.Add(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditEducation(Education education)
        {
            db.Entry(education).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddFamilyMember()
        {
            return PartialView("_AddFamilyMember");
        }

        public PartialViewResult EditFamilyMember(int id)
        {
            FamilyMember familyMember = db.FamilyMembers.Find(id);
            return PartialView("_EditFamilyMember", familyMember);
        }

        [HttpPost]
        public ActionResult AddFamilyMember(FamilyMember familyMember)
        {
            familyMember.UserId = (int)Session["UserId"];
            FamilyMember aFamilyMember = db.FamilyMembers.Add(familyMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditFamilyMember(FamilyMember familyMember)
        {
            db.Entry(familyMember).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddSkills()
        {
            return PartialView("_AddSkill");
        }

        public PartialViewResult EditSkills(int id)
        {
            ProfessionalSkill skill = db.ProfessionalSkills.Find(id);
            return PartialView("_EditSkill", skill);
        }

        [HttpPost]
        public ActionResult AddSkills(ProfessionalSkill skill)
        {
            skill.UserId = (int)Session["UserId"];
            ProfessionalSkill aSkill = db.ProfessionalSkills.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditSkills(ProfessionalSkill skill)
        {
            db.Entry(skill).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddExperience()
        {
            return PartialView("_AddWork");
        }

        public PartialViewResult EditExperience(int id)
        {
            Work work = db.Works.Find(id);
            return PartialView("_EditWork", work);
        }

        [HttpPost]
        public ActionResult AddExperience(Work work)
        {
            work.UserId = (int)Session["UserId"];
            Work aWork = db.Works.Add(work);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditExperience(Work work)
        {
            db.Entry(work).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddPersonalInfo()
        {
            //            Profile profile = GetBasicInfos().Profile;
            return PartialView("_AddProfile");
        }

        public PartialViewResult EditPersonalInfo()
        {
            Profile profile = GetBasicInfos().Profile;
            return PartialView("_EditProfile", profile);
        }

        [HttpPost]
        public ActionResult AddPersonalInfo(Profile profile)
        {
            profile.UserId = (int)Session["UserId"];
            Profile aProfile = db.Profiles.Add(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditPersonalInfo(Profile profile, string day, string month, string year)
        {
            profile.FullName = profile.FirstName + " " + profile.LastName;
            profile.DOB = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            db.Entry(profile).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddMobileNo()
        {
            return PartialView("_AddMobileNo");
        }

        public PartialViewResult EditMobileNo(int id)
        {
            MobileNo mobileNo = db.MobileNoes.Find(id);
            return PartialView("_EditMobileNo", mobileNo);
        }

        [HttpPost]
        public ActionResult AddMobileNo(MobileNo mobileNo)
        {
            mobileNo.UserId = (int)Session["UserId"];
            MobileNo aMobileNo = db.MobileNoes.Add(mobileNo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditMobileNo(MobileNo mobileNo)
        {
            db.Entry(mobileNo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult AddInterest()
        {
            return PartialView("_AddInterest");
        }

        public PartialViewResult EditInterest(int id)
        {
            Interest interest = db.Interests.Find(id);
            return PartialView("_EditInterest", interest);
        }

        [HttpPost]
        public ActionResult AddInterest(Interest interest)
        {
            interest.UserId = (int)Session["UserId"];
            Interest anInterest = db.Interests.Add(interest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditInterest(Interest interest)
        {
            db.Entry(interest).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        private BasicInfo GetBasicInfos()
        {
            int userId = (int)Session["UserId"];

            BasicInfo basicInfo = new BasicInfo
            {
                Address = db.Addresses.Find(userId),
                Educations = db.Educations.Where(a => a.UserId == userId).ToList(),
                FamilyMembers = db.FamilyMembers.Where(a => a.UserId == userId).ToList(),
                Interests = db.Interests.Where(a => a.UserId == userId).ToList(),
                MobileNos = db.MobileNoes.Where(a => a.UserId == userId).ToList(),
                ProfessionalSkills = db.ProfessionalSkills.Where(a => a.UserId == userId).ToList(),
                Profile = db.Profiles.Find(userId),
                Works = db.Works.Where(a => a.UserId == userId).ToList()
            };
            return basicInfo;
        }
    }
}
