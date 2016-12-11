using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Institute { get; set; }

        [DisplayName("From Date")]
        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To Date")]
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public bool? HasDegree { get; set; }

        [StringLength(50)]
        public string Degree { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
