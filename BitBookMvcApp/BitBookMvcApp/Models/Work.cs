using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Work")]
    public partial class Work
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [DisplayName("From Date")]
        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To Date")]
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
