using System.Threading.Tasks;
using AFI.Registration.Models;

namespace AFI.Registration.Interfaces.Respositories
{
    public interface IRegistrationRepository
    {
        Task<int> CreateRegistration(RegistrationModel model);
    }
}
