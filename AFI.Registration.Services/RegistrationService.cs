using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks;
using AFI.Registration.Interfaces;
using AFI.Registration.Interfaces.Services;
using AFI.Registration.Models;

namespace AFI.Registration.Services
{
    public class RegistrationService : IRegistrationService
    {
        public async Task<int> RegisterCustomer(RegistrationModel model)
        {
            var ret = -1;
            
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

                return await Task.FromResult(ret);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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

            return dateOfBirth == null || dateOfBirth == DateTime.MinValue;
            
        }

        
    }
}
