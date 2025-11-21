using CMCS4.Domain.DTOs;
using CMCS4.Domain.Entities;
using CMCS4.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace CMCS4.Services.Interfaces
{
    public interface IClaimService
    {
        Task<Claim> SubmitClaimAsync(ClaimCreateDto dto);
        Task<Claim> UploadSupportingDocumentAsync(int claimId, IFormFile file);
        Task UpdateClaimStatusAsync(int claimId, ClaimStatus status);
        Task<List<Claim>> GetPendingClaimsAsync();
        Task<List<Claim>> GetClaimsForLecturerAsync();
    }
}
