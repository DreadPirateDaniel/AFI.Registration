using System;
using System.ComponentModel.DataAnnotations;

namespace AFI.Registration.Models
{
    public class RegistrationModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 characters.")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Surname must be between 3 and 50 characters.")]
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required( ErrorMessage = "Policy Reference Number is required")]
        [RegularExpression("\\[A-Z]{2}-\\d{6}", ErrorMessage = "Policy Reference Number must be in the format XX-999999")]
        public string PolicyReferenceNumber { get; set; }
        public string Email { get; set; }

        //todo: work out validator for over 18 if provided
        public DateTime? DateOfBirth { get; set; }
    }
}
