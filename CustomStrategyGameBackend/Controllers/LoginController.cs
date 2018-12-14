using CustomStrategyGameBackend.ComModels;
using CustomStrategyGameBackend.Communicators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomStrategyGameBackend.Controllers
{
    public class LoginController : ApiController
    {
        // POST: api/Login
        public HttpResponseMessage Post(HttpRequestMessage value)
        {
            return new LoginCommunicator().GetLoggedIn(value.Content.ReadAsStringAsync().Result);
        }
    }
}
