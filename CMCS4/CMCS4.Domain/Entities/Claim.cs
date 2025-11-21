using CMCS4.Domain.Enums;

namespace CMCS4.Domain.Entities
{
    public class Claim
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal TotalPayment { get; set; }
        public string? Notes { get; set; }
        public string? DocumentPath { get; set; }
        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
