using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        [DisplayName("Comment")]
        [Column("Comment")]
        [StringLength(500)]
        public string Comment1 { get; set; }

        public int? PostId { get; set; }

        public DateTime? Time { get; set; }

        public int? WhoCommentedId { get; set; }

        public virtual User User { get; set; }
    }
}
