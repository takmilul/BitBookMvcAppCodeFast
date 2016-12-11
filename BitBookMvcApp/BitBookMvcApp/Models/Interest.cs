using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Interest")]
    public partial class Interest
    {
        public int Id { get; set; }

        [DisplayName("Interested In")]
        [StringLength(500)]
        public string InterestedIn { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
