namespace GTT.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Day_Connection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Day_Connection()
        {
            Tour1 = new HashSet<Tour>();
        }

        public int Id { get; set; }

        public int? DayID { get; set; }

        public int? NextDayID { get; set; }

        public int? TourID { get; set; }

        public virtual Day Day { get; set; }

        public virtual Day Day1 { get; set; }

        public virtual Tour Tour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour> Tour1 { get; set; }
    }
}
