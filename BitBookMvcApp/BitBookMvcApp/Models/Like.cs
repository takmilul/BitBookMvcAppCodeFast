namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Like")]
    public partial class Like
    {
        public int Id { get; set; }

        public int? PostId { get; set; }

        public int? WhoLikedId { get; set; }

        public virtual User User { get; set; }
    }
}
