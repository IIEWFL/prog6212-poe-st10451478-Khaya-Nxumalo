using CMCS4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

//Microsoft (2023) EF Core DbContext Documentation. Available at: https://learn.microsoft.com/ef/core/dbcontext-configuration/(Accessed: 21 November 2025).

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
