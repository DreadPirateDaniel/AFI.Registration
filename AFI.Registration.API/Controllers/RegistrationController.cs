using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AFI.Registration.API.Controllers
{
    public class RegistrationController : Controller
    {

        [HttpPost]
        public HttpStatusCode RegisterCustomer(string firstnName, string lastname, string referennceNumber, string dateOfBirth = null, string email = null)
        {
            var ret = new HttpStatusCode();

            return ret;
        }
    }
}
