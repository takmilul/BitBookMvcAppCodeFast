namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProfessionalSkill
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Skill { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
