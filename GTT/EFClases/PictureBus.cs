namespace GTT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PictureBus
    {
        public int ID { get; set; }

        public int? BusID { get; set; }

        [Column(TypeName = "text")]
        public string PicturePath { get; set; }

        public virtual Bus Bus { get; set; }
    }
}
