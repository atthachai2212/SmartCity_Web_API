namespace SmartCity_Web_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Configuration;

    public partial class dbBusTrackingContext : DbContext
    {
        public dbBusTrackingContext()
            : base(string.Format(ConfigurationManager.ConnectionStrings["dbBusTrackingContext"].ConnectionString,DateTime.Now.Year))
        {
        }

        public virtual DbSet<tbGPS> tbGPS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbGPS>()
                .Property(e => e.Time)
                .HasPrecision(0);
        }
    }
}
