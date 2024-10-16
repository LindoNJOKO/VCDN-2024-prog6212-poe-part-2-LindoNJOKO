using System;
using System.ComponentModel.DataAnnotations;

namespace ST10021160.PROG.POE.PT2.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal HoursWorked { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        public string AdditionalNotes { get; set; }

        public decimal ClaimAmount => HoursWorked * HourlyRate;

        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        public string AttachedFilePath { get; set; }
    }

}
