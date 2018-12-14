using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomStrategyGameBackend.Controllers
{
    public class GameSessionController : ApiController
    {
        // GET: api/GameSession
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GameSession/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GameSession
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GameSession/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GameSession/5
        public void Delete(int id)
        {
        }
    }
}
