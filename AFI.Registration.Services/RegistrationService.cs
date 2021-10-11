using System;
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
            throw new NotImplementedException();
        }
    }
}
