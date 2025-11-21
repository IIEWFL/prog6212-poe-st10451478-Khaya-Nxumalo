using CMCS4.Data.Interfaces;
using CMCS4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

//Seemann, M. (2019) Dependency Injection Principles, Practices, and Patterns. Pearson.

namespace CMCS4.Data.Repositories
{
    public class ClaimRepository : GenericRepository<Claim>, IClaimRepository
    {
        private readonly CMCS4DbContext _context;

        public ClaimRepository(CMCS4DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Claim>> GetClaimsByLecturerAsync(int lecturerId)
        {
            return await _context.Claims
                .Where(c => c.LecturerId == lecturerId)
                .ToListAsync();
        }

        public async Task<List<Claim>> GetPendingClaimsAsync()
        {
            return await _context.Claims
                .Where(c => c.Status == Domain.Enums.ClaimStatus.Pending)
                .ToListAsync();
        }
    }
}
