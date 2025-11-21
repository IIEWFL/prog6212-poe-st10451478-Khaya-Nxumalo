using System.Security.Claims;

namespace CMCS4.Domain.Entities
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public decimal HourlyRate { get; set; }

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}
