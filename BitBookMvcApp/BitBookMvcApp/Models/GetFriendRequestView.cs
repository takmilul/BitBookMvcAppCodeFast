using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GetFriendRequestView")]
    public partial class GetFriendRequestView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? SenderId { get; set; }

        public int? ReceiverId { get; set; }

        [DisplayName("Full Name")]
        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string ProPic { get; set; }

        public bool? IsAccepted { get; set; }
    }
}
