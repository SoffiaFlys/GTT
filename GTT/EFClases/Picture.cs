namespace GTT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Picture")]
    public partial class Picture
    {
        public int ID { get; set; }

        public int? TourID { get; set; }

        [Column(TypeName = "text")]
        public string PicturePath { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
