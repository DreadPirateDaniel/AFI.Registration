using System.Threading.Tasks;
using AFI.Registration.Models;

namespace AFI.Registration.Interfaces.Services
{
    public interface IRegistrationService
    {
        Task<int> RegisterCustomer(RegistrationModel model);
    }
}
