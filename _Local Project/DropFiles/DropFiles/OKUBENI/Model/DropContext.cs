namespace DropFiles.OKUBENI.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DropContext : DbContext
    {
        public DropContext()
            : base("name=DropContext")
        {
        }

        public virtual DbSet<wDosya> wDosyas { get; set; }
        public virtual DbSet<wSipari> wSiparis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<wSipari>()
                .HasMany(e => e.wDosyas)
                .WithRequired(e => e.wSipari)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);
        }
    }
}
