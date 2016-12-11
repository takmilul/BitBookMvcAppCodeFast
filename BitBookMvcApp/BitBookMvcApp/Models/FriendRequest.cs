namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FriendRequest")]
    public partial class FriendRequest
    {
        public int Id { get; set; }

        public int? SenderId { get; set; }

        public int? ReceiverId { get; set; }

        public bool? IsAccepted { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
