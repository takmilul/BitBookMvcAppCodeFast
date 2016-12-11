using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBookMvcApp.Models;

namespace BitBookMvcApp.ViewModels
{
    public class BasicInfo
    {
        public int Id { get; set; }
        
        public virtual Address Address { get; set; }
        
        public virtual List<Education> Educations { get; set; }
        
        public virtual List<FamilyMember> FamilyMembers { get; set; }
        
        public virtual List<Interest> Interests { get; set; }
        
        public virtual List<MobileNo> MobileNos { get; set; }
        
        public virtual List<ProfessionalSkill> ProfessionalSkills { get; set; }
        
        public virtual Profile Profile { get; set; }
        
        public virtual List<Work> Works { get; set; }
    }
}