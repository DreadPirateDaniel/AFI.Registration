using System;
using System.Threading.Tasks;
using AFI.Registration.Interfaces.Respositories;
using AFI.Registration.Models;

namespace AFI.Registration.Repositories
{
    public class RegistrationRespository : IRegistrationRepository
    {
        public Task<int> CreateRegistration(RegistrationModel model)
        {
            throw new NotImplementedException();
        }
    }
}
