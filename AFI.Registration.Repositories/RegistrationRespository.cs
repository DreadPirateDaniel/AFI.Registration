using System;
using System.Threading.Tasks;
using AFI.Registration.Interfaces.Respositories;
using AFI.Registration.Models;

namespace AFI.Registration.Repositories
{
    public class RegistrationRespository : IRegistrationRepository
    {
        /// <summary>
        /// New instance of the Registration Repository
        /// </summary>
        public RegistrationRespository()
        {

        }

        /// <summary>
        /// Creates a Customer Registration in the DBase
        /// </summary>
        /// <param name="model">RegistrationModel</param>
        /// <returns>async Int, positive if success negative if failure</returns>
        public Task<int> CreateRegistration(RegistrationModel model)
        {
            throw new NotImplementedException();
        }
    }
}
