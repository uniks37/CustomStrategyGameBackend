using CustomStrategyGameBackend.Communicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomStrategyGameBackend.Controllers
{
    public class LogoutController : ApiController
    {
        // GET: api/Logout
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // POST: api/Logout
        public HttpRequestMessage Post(HttpRequestMessage value)
        {
            new LogoutCommunicator().GetLoggedOut(value.Content.ReadAsStringAsync().Result);
            return new HttpRequestMessage();
        }
    }
}
