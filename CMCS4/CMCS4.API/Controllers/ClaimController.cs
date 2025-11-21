using CMCS4.Domain.DTOs;
using CMCS4.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;

//Microsoft (2023) ASP.NET Core Web API Documentation. Available at: https://learn.microsoft.com/aspnet/core/web-api(Accessed: 21 November 2025).

namespace CMCS4.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        // Lecturer submits a claim
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitClaim([FromBody] ClaimCreateDto dto)
        {
            var result = await _claimService.SubmitClaimAsync(dto);
            return Ok(result);
        }

        // Lecturer uploads supporting documents
        [HttpPost("{claimId}/upload")]
        public async Task<IActionResult> UploadDocument(int claimId, [FromForm] IFormFile file)
        {
            var result = await _claimService.UploadSupportingDocumentAsync(claimId, file);
            return Ok(result);
        }

        // Get pending claims (Coordinator / Manager)
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingClaims()
        {
            var claims = await _claimService.GetPendingClaimsAsync();
            return Ok(claims);
        }

        // Approve a claim
        [HttpPost("{claimId}/approve")]
        public async Task<IActionResult> ApproveClaim(int claimId)
        {
            await _claimService.UpdateClaimStatusAsync(claimId, Domain.Enums.ClaimStatus.Approved);
            return Ok(new { Message = "Claim approved." });
        }

        // Reject a claim
        [HttpPost("{claimId}/reject")]
        public async Task<IActionResult> RejectClaim(int claimId)
        {
            await _claimService.UpdateClaimStatusAsync(claimId, Domain.Enums.ClaimStatus.Rejected);
            return Ok(new { Message = "Claim rejected." });
        }

        // Get all claims for a lecturer
        [HttpGet("my-claims")]
        public async Task<IActionResult> GetMyClaims()
        {
            var result = await _claimService.GetClaimsForLecturerAsync();
            return Ok(result);
        }
    }
}
