namespace GTT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourDate")]
    public partial class TourDate
    {
        public int ID { get; set; }

        public int? TourID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        public TimeSpan? Duration { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
