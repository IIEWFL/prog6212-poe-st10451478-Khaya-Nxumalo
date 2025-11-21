using CMCS4.Data.Interfaces;
using CMCS4.Domain.DTOs;
using CMCS4.Domain.Entities;
using CMCS4.Domain.Enums;
using CMCS4.Services.Interfaces;
using Microsoft.AspNetCore.Http;

//Fowler, M. (2003) Patterns of Enterprise Application Architecture. Boston: Addison-Wesley.

namespace CMCS4.Services.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepo;

        public ClaimService(IClaimRepository claimRepo)
        {
            _claimRepo = claimRepo;
        }

        public async Task<Claim> SubmitClaimAsync(ClaimCreateDto dto)
        {
            var claim = new Claim
            {
                LecturerId = dto.LecturerId,
                HoursWorked = dto.HoursWorked,
                HourlyRate = dto.HourlyRate,
                TotalPayment = dto.HoursWorked * dto.HourlyRate,
                Notes = dto.Notes,
                Status = ClaimStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            return await _claimRepo.AddAsync(claim);
        }

        public async Task<Claim> UploadSupportingDocumentAsync(int claimId, IFormFile file)
        {
            var claim = await _claimRepo.GetAsync(claimId)
                ?? throw new Exception("Claim not found.");

            var path = Path.Combine("Uploads", $"{Guid.NewGuid()}_{file.FileName}");
            Directory.CreateDirectory("Uploads");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            claim.DocumentPath = path;

            return await _claimRepo.UpdateAsync(claim);
        }

        public async Task UpdateClaimStatusAsync(int claimId, ClaimStatus status)
        {
            var claim = await _claimRepo.GetAsync(claimId)
                ?? throw new Exception("Claim not found.");

            claim.Status = status;
            await _claimRepo.UpdateAsync(claim);
        }

        public async Task<List<Claim>> GetPendingClaimsAsync()
        {
            return await _claimRepo.GetPendingClaimsAsync();
        }

        public async Task<List<Claim>> GetClaimsForLecturerAsync()
        {
            /// In real world: extract lecturerId from JWT.
            int lecturerId = 1;

            return await _claimRepo.GetClaimsByLecturerAsync(lecturerId);
        }
    }
}
