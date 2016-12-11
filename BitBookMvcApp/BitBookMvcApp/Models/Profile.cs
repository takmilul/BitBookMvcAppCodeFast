using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Gender { get; set; }

        public int? ProPicId { get; set; }

        public int? CoverPicId { get; set; }

        [StringLength(50)]
        public string Religion { get; set; }
        
        public bool? HasRelationship { get; set; }

        [DisplayName("Relationship")]
        public int? RelationshipId { get; set; }

        [DisplayName("Relationship With")]
        public int? RelationshipWithId { get; set; }

        [StringLength(50)]
        public string About { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
