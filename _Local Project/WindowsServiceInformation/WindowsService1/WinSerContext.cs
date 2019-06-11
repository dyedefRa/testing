namespace WindowsService1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WindowsService1.Model;

    public partial class WinSerContext : DbContext
    {
        public WinSerContext()
            : base("name=WinSerContext")
        {
        }

        public virtual DbSet<DosyaOlaylari> DosyaOlaylaris { get; set; }
        public virtual DbSet<EylemTurleri> EylemTurleris { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EylemTurleri>()
                .HasMany(e => e.DosyaOlaylaris)
                .WithOptional(e => e.EylemTurleri)
                .HasForeignKey(e => e.EventTurId);
        }
    }
}
