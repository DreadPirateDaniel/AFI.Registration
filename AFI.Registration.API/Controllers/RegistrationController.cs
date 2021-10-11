using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AFI.Registration.Models;
using AFI.Registration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Registration.API.Controllers
{
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [Route("api/registration/registercustomer")]
        [HttpPost]
        public async Task RegisterCustomer(string firstname, string surname, string policyreferencenumber, string email, DateTime? dateOfBirth)
        {
            var registrationService = new RegistrationService();

            var model = new RegistrationModel
            {
                FirstName = firstname,
                Surname = surname,
                PolicyReferenceNumber = policyreferencenumber,
                DateOfBirth = dateOfBirth
            };

            var ret = await registrationService.RegisterCustomer(model);
        }
    }
}
