using System;

namespace AFI.Registration.Models
{
    public class RegistrationModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
