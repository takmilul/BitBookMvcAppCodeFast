using System.ComponentModel;

namespace BitBookMvcApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        public int Id { get; set; }

        [DisplayName("Current City")]
        [StringLength(50)]
        public string CurrentCity { get; set; }

        [DisplayName("Current Country")]
        [StringLength(50)]
        public string CurrentCountry { get; set; }

        [DisplayName("From City")]
        [StringLength(50)]
        public string FromCity { get; set; }

        [DisplayName("From Country")]
        [StringLength(50)]
        public string FromCountry { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
