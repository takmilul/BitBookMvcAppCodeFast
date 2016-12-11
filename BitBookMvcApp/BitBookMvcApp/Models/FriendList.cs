namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FriendList")]
    public partial class FriendList
    {
        public int Id { get; set; }

        public int? FriendId { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
