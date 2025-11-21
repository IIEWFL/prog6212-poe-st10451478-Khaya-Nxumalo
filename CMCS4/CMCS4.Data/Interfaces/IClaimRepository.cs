using CMCS4.Domain.Entities;

//Evans, E. (2004) Domain-Driven Design: Tackling Complexity in the Heart of Software. Boston: Addison-Wesley.

namespace CMCS4.Data.Interfaces
{
    public interface IClaimRepository : IGenericRepository<Claim>
    {
        Task<List<Claim>> GetClaimsByLecturerAsync(int lecturerId);
        Task<List<Claim>> GetPendingClaimsAsync();
    }
}
