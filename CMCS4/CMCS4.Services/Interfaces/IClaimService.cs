using CMCS4.Domain.DTOs;
using CMCS4.Domain.Entities;

namespace CMCS4.Services.Interfaces
{
    public interface IClaimService
    {
        Task<Claim> SubmitClaimAsync(ClaimCreateDto dto);
        Task<Claim> ApproveClaimAsync(ClaimApproveDto dto);
        Task<List<Claim>> GetPendingClaimsAsync();
        Task<List<Claim>> GetLecturerClaimsAsync(int lecturerId);
    }
}
