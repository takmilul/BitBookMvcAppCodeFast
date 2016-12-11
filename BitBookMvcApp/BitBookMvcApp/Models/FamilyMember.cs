using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FamilyMember")]
    public partial class FamilyMember
    {
        public int Id { get; set; }

        public int? FamilyMemberId { get; set; }

        [DisplayName("Relationship")]
        public int? RelationshipId { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
