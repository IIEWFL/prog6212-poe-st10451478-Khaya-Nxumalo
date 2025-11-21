using CMCS4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CMCS4.Data
{
    public class CMCS4DbContext : DbContext
    {
        public CMCS4DbContext(DbContextOptions<CMCS4DbContext> options)
            : base(options) { }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
