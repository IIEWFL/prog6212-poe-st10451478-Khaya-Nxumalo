using CMCS4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMCS4.Data
{
    public class CMCS4DbContext : DbContext
    {
        public CMCS4DbContext(DbContextOptions<CMCS4DbContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.HourlyRate)
                    .HasPrecision(18, 2);

                entity.Property(c => c.TotalPayment)
                    .HasPrecision(18, 2);
            });
        }
    }
}
