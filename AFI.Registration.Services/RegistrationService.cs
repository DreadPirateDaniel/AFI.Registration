using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AFI.Registration.Interfaces.Respositories;
using AFI.Registration.Interfaces.Services;
using AFI.Registration.Models;
using AFI.Registration.Repositories;

namespace AFI.Registration.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        /// <summary>
        /// New instance of the Registration Service
        /// </summary>
        public RegistrationService()
        {
            _registrationRepository = new RegistrationRespository();
        }

        /// <summary>
        /// Injectable instance of the registration service
        /// </summary>
        /// <param name="registrationRepository"></param>
        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        /// <summary>
        /// Registers a Cusstomer in the AFI database and returns a unique customer number
        /// </summary>
        /// <param name="model">Registration Model</param>
        /// <returns>Postive int on success, negative int on failure</returns>
        public async Task<int> RegisterCustomer(RegistrationModel model)
        {
            const int ret = -1;

            try
            {
                var vc = new ValidationContext(model);

                var results = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(model, vc, results, true);

                //todo: return error message with result
                if (!isValid)
                {
                    return ret;
                }
                
                isValid = ValidateEmailDateOfBirth(model.Email, model.DateOfBirth);

                //todo: return error message with result
                if (!isValid)
                {
                    return ret;
                }

                return await _registrationRepository.CreateRegistration(model);
            }
            catch (Exception e)
            {
                //would normally implement correct error handling here
                //for the puporses of test, -1 indicates a failure
                return -1;
            }
        }

        //This is a pretty dirty method to validate this requirement, I would generally create
        //a customer attribute to manage this as part of the original validation context
        public bool ValidateEmailDateOfBirth(string email, DateTime? dateOfBirth)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                return true;
            }

            return dateOfBirth != null && dateOfBirth != DateTime.MinValue;
            
        }

    }
}
