using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AFI.Registration.Interfaces.Respositories;
using AFI.Registration.Models;
using Newtonsoft.Json;

namespace AFI.Registration.Repositories
{
    /// <summary>
    /// For simplicity I've used a file based repo. Normally I would have used a SQL dbase or an Entity Framework model tied to a dbase.
    /// From experience, shipping dbases for tests is a pain and I wanted this to be as simple as possible.
    /// I appreciate with an aysncronous setup, this isn't maintanable under this current system due to multiple requests potetially hitting
    /// at once
    /// </summary>
    public class RegistrationRespository : IRegistrationRepository
    {
        private readonly string _dataPath;
        /// <summary>
        /// New instance of the Registration Repository
        /// </summary>
        public RegistrationRespository()
        {
            _dataPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\AppData\\DataBase.json";
        }

        /// <summary>
        /// Creates a Customer Registration in the DBase
        /// </summary>
        /// <param name="model">RegistrationModel</param>
        /// <returns>async Int, positive if success negative if failure</returns>
        public async Task<int> CreateRegistration(RegistrationModel model)
        {
            var list = new List<RegistrationModel> {model};

            model.CustomerId = GetNewCustomerId();

            if (WriteModel((model)))
            {
                return model.CustomerId;}

            return WriteModel(model) ? await Task.FromResult(model.CustomerId) : await Task.FromResult(-1);
            
        }

        /// <summary>
        /// Writes a model to the data base
        /// </summary>
        /// <param name="model">Registration Model</param>
        /// <returns>bool</returns>
        private bool WriteModel(RegistrationModel model)
        {
            var dbase = JsonConvert.DeserializeObject<List<RegistrationModel>>(File.ReadAllText($@"{_dataPath}"));

            dbase.Add(model);

            File.WriteAllText(_dataPath, JsonConvert.SerializeObject(dbase));

            return true;
        }

        /// <summary>
        /// Returns new customer id from file base dbase, in a SQL based system this would not be needed
        /// you would use an identity column and return that
        /// </summary>
        /// <returns>int</returns>
        private int GetNewCustomerId()
        {
            var customers = JsonConvert.DeserializeObject<List<RegistrationModel>>(File.ReadAllText($@"{_dataPath}"));

            if (customers == null || customers.Count == 0)
            {
                return 1;
            }

            return customers.OrderByDescending(x => x.CustomerId).First().CustomerId + 1;

        }
    }
}
