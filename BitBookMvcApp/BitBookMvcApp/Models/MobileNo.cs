using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MobileNo")]
    public partial class MobileNo
    {
        public int Id { get; set; }

        [DisplayName("Mobile No")]
        [Column("MobileNo")]
        [StringLength(50)]
        public string MobileNo1 { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
