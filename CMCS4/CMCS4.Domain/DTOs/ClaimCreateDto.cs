namespace CMCS4.Domain.DTOs
{
    public class ClaimCreateDto
    {
        public int LecturerId { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string? Notes { get; set; }
    }
}
