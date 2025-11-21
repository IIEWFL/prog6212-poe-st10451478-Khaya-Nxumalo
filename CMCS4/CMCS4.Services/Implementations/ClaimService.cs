using CMCS4.Data.Interfaces;
using CMCS4.Domain.DTOs;
using CMCS4.Domain.Entities;
using CMCS4.Domain.Enums;
using CMCS4.Services.Interfaces;

namespace CMCS4.Services.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly IGenericRepository<Claim> _claimRepo;

        public ClaimService(IGenericRepository<Claim> claimRepo)
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
                Notes = dto.Notes
            };

            return await _claimRepo.AddAsync(claim);
        }

        public async Task<Claim> ApproveClaimAsync(ClaimApproveDto dto)
        {
            var claim = await _claimRepo.GetAsync(dto.ClaimId)
                ?? throw new Exception("Claim not found.");

            claim.Status = dto.Approve ? ClaimStatus.Approved : ClaimStatus.Rejected;

            return await _claimRepo.UpdateAsync(claim);
        }

        public async Task<List<Claim>> GetPendingClaimsAsync()
        {
            var all = await _claimRepo.GetAllAsync();
            return all.Where(c => c.Status == ClaimStatus.Pending).ToList();
        }

        public async Task<List<Claim>> GetLecturerClaimsAsync(int lecturerId)
        {
            var all = await _claimRepo.GetAllAsync();
            return all.Where(c => c.LecturerId == lecturerId).ToList();
        }
    }
}
