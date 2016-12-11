using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int Id { get; set; }

        [DisplayName("Post")]
        [Column("Post")]
        [StringLength(5000)]
        public string Post1 { get; set; }

        [StringLength(500)]
        public string PicUrl { get; set; }

        public bool? IsText { get; set; }

        public bool? IsPic { get; set; }

        public DateTime? Date { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
