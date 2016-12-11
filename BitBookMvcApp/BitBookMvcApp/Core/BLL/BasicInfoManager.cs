using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Core.DAL;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.Core.BLL
{
    public class BasicInfoManager
    {
        BasicInfoGateway _basicInfoGateway = new BasicInfoGateway();

        public int AddAddress(Address address)
        {
            return _basicInfoGateway.AddAddress(address);
        }

        public int UpdateAddress(Address address)
        {
            return _basicInfoGateway.UpdateAddress(address);
        }

        public Address GetAddress(int userId)
        {
            return _basicInfoGateway.GetAddress(userId);
        }

        public int AddEducation(Education education)
        {
            return _basicInfoGateway.AddEducation(education);
        }

        public int UpdateEducation(Education education)
        {
            return _basicInfoGateway.UpdateEducation(education);
        }

        public Education GetEducation(int educationId)
        {
            return _basicInfoGateway.GetEducation(educationId);
        }

        public List<Education> GetAllEducations(int userId)
        {
            return _basicInfoGateway.GetAllEducations(userId);
        }

        public int RemoveEducation(int educationId)
        {
            return _basicInfoGateway.RemoveEducation(educationId);
        }

        public int AddWork(Work work)
        {
            return _basicInfoGateway.AddWork(work);
        }

        public int UpdateWork(Work work)
        {
            return _basicInfoGateway.UpdateWork(work);
        }

        public Work GetWork(int workId)
        {
            return _basicInfoGateway.GetWork(workId);
        }

        public List<Work> GetAllWork(int userId)
        {
            return _basicInfoGateway.GetAllWork(userId);
        }

        public int RemoveWork(int workId)
        {
            return _basicInfoGateway.RemoveWork(workId);
        }

        public int AddMobileNo(MobileNo mobileNo)
        {
            return _basicInfoGateway.AddMobileNo(mobileNo);
        }

        public int UpdateMobileNo(MobileNo mobileNo)
        {
            return _basicInfoGateway.UpdateMobileNo(mobileNo);
        }

        public MobileNo GetMobileNo(int mobileNoId)
        {
            return _basicInfoGateway.GetMobileNo(mobileNoId);
        }

        public List<MobileNo> GetAllMobileNo(int userId)
        {
            return _basicInfoGateway.GetAllMobileNo(userId);
        }

        public int RemoveMobileNo(int mobileNoId)
        {
            return _basicInfoGateway.RemoveMobileNo(mobileNoId);
        }

        public int AddProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            return _basicInfoGateway.AddProfessionalSkill(professionalSkill);
        }

        public int UpdateProfessionalSkill(ProfessionalSkill professionalSkill)
        {
            return _basicInfoGateway.UpdateProfessionalSkill(professionalSkill);
        }

        public ProfessionalSkill GetProfessionalSkill(int professionalSkillId)
        {
            return _basicInfoGateway.GetProfessionalSkill(professionalSkillId);
        }

        public List<ProfessionalSkill> GetAllProfessionalSkills(int userId)
        {
            return _basicInfoGateway.GetAllProfessionalSkills(userId);
        }

        public int RemoveProfessionalSkill(int professionalSkillId)
        {
            return _basicInfoGateway.RemoveProfessionalSkill(professionalSkillId);
        }

        public int AddInterest(Interest interest)
        {
            return _basicInfoGateway.AddInterest(interest);
        }

        public int UpdateInterest(Interest interest)
        {
            return _basicInfoGateway.UpdateInterest(interest);
        }

        public Interest GetInterest(int interestId)
        {
            return _basicInfoGateway.GetInterest(interestId);
        }

        public List<Interest> GetAllInterests(int userId)
        {
            return _basicInfoGateway.GetAllInterests(userId);
        }

        public int RemoveInterest(int interestId)
        {
            return _basicInfoGateway.RemoveInterest(interestId);
        }

        public int AddFamilyMember(FamilyMember familyMember)
        {
            return _basicInfoGateway.AddFamilyMember(familyMember);
        }

        public int UpdateFamilyMember(FamilyMember familyMember)
        {
            return _basicInfoGateway.UpdateFamilyMember(familyMember);
        }

        public FamilyMember GetFamilyMember(int familyMemberId)
        {
            return _basicInfoGateway.GetFamilyMember(familyMemberId);
        }

        public List<FamilyMember> GetAllFamilyMembers(int userId)
        {
            return _basicInfoGateway.GetAllFamilyMembers(userId);
        }

        public int RemoveFamilyMember(int id)
        {
            return _basicInfoGateway.RemoveFamilyMember(id);
        }
    }
}