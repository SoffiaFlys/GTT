namespace GTT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Route_Connection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route_Connection()
        {
            Tour1 = new HashSet<Tour>();
        }

        public int ID { get; set; }

        public int? LocationID { get; set; }

        public int? NextLocation { get; set; }

        public int? TourID { get; set; }

        public virtual TourLocation TourLocation { get; set; }

        public virtual TourLocation TourLocation1 { get; set; }

        public virtual Tour Tour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour> Tour1 { get; set; }
    }
}
