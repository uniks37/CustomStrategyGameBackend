using CustomStrategyGameBackend.Communicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomStrategyGameBackend.Controllers
{
    public class RegistrationController : ApiController
    {
        // POST: api/Registration
        public HttpResponseMessage Post(HttpRequestMessage value)
        {
            return new RegistrationCommunicator().GetRegistered(value.Content.ReadAsStringAsync().Result);
        }
    }
}
