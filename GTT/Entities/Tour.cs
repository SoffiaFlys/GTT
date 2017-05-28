namespace GTT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Day_Connection = new HashSet<Day_Connection>();
            Picture = new HashSet<Picture>();
            Route_Connection = new HashSet<Route_Connection>();
            TourDate = new HashSet<TourDate>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal? PriceUSD { get; set; }

        public int? StartConnectionID { get; set; }

        public int? ProgramFirstDayID { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int? FoodTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Day_Connection> Day_Connection { get; set; }

        public virtual Day_Connection Day_Connection1 { get; set; }

        public virtual FoodType FoodType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route_Connection> Route_Connection { get; set; }

        public virtual Route_Connection Route_Connection1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourDate> TourDate { get; set; }
    }
}
