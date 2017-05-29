namespace GTT.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BusContext : DbContext
    {
        public BusContext()
            : base("name=BusContext")
        {
        }

        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<BusEquipment> BusEquipment { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<PictureBus> PictureBus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
                .Property(e => e.Seats)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PictureBus>()
                .Property(e => e.PicturePath)
                .IsUnicode(false);
        }
    }
}
