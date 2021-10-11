using System;
using System.Threading.Tasks;
using AFI.Registration.Models;
using AFI.Registration.Services;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Registration.API.Controllers
{
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [Route("api/registration/registercustomer")]
        [HttpPost]
        public async Task<int> RegisterCustomer(string firstname, string surname, string policyreferencenumber, string email, DateTime? dateOfBirth)
        {
            var registrationService = new RegistrationService();

            var model = new RegistrationModel
            {
                FirstName = firstname,
                Surname = surname,
                PolicyReferenceNumber = policyreferencenumber,
                Email = email,
                DateOfBirth = dateOfBirth
            };

            //depending on application, would return a resonse message here to indicate exceptions
            //currently all errors return a -1 for the customer number but would implement proper
            //status codes and response messages with more time
            return await registrationService.RegisterCustomer(model);

        }
    }
}
