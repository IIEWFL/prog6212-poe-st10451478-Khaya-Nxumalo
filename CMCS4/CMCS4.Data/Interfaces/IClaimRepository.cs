using CMCS4.Domain.Entities;

namespace CMCS4.Data.Interfaces
{
    public interface IClaimRepository : IGenericRepository<Claim>
    {
        Task<List<Claim>> GetClaimsByLecturerAsync(int lecturerId);
        Task<List<Claim>> GetPendingClaimsAsync();
    }
}
