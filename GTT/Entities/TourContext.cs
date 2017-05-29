namespace GTT.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TourContext : DbContext
    {
        public TourContext()
            : base("name=TourContext")
        {
        }

        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Day_Connection> Day_Connection { get; set; }
        public virtual DbSet<FoodType> FoodType { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Route_Connection> Route_Connection { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<TourDate> TourDate { get; set; }
        public virtual DbSet<TourLocation> TourLocation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Day_Connection)
                .WithOptional(e => e.Day)
                .HasForeignKey(e => e.DayID);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Day_Connection1)
                .WithOptional(e => e.Day1)
                .HasForeignKey(e => e.NextDayID);

            modelBuilder.Entity<Day_Connection>()
                .HasMany(e => e.Tour1)
                .WithOptional(e => e.Day_Connection1)
                .HasForeignKey(e => e.ProgramFirstDayID);

            modelBuilder.Entity<FoodType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Picture>()
                .Property(e => e.PicturePath)
                .IsUnicode(false);

            modelBuilder.Entity<Route_Connection>()
                .HasMany(e => e.Route_Connection1)
                .WithOptional(e => e.Route_Connection2)
                .HasForeignKey(e => e.NextConnectionID);

            modelBuilder.Entity<Route_Connection>()
                .HasMany(e => e.Tour1)
                .WithOptional(e => e.Route_Connection1)
                .HasForeignKey(e => e.StartConnectionID);

            modelBuilder.Entity<Tour>()
                .Property(e => e.PriceUSD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tour>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Day_Connection)
                .WithOptional(e => e.Tour)
                .HasForeignKey(e => e.TourID);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.Route_Connection)
                .WithOptional(e => e.Tour)
                .HasForeignKey(e => e.TourID);

            modelBuilder.Entity<TourLocation>()
                .HasMany(e => e.Route_Connection)
                .WithOptional(e => e.TourLocation)
                .HasForeignKey(e => e.LocationID);
        }
    }
}
