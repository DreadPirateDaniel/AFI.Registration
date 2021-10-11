using System;
using System.ComponentModel.DataAnnotations;

namespace AFI.Registration.Models
{
    public class RegistrationModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required( ErrorMessage = "Policy Reference Number is required")]
        [RegularExpression("\\[A-Z]{2}-\\d{6}", ErrorMessage = "Policy Reference Number must be in the format XX-999999")]
        public string PolicyReferenceNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
