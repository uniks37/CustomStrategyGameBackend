using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CustomStrategyGameBackend.Models;

namespace CustomStrategyGameBackend.Controllers
{
    public class GamerSearchController : ApiController
    {
        private GameModel db = new GameModel();

        // GET: api/GamerSearch/a
        public IQueryable<char> GetGamers(string uname)
        {
            return db.Gamers
                .Where(g => (g.IsOnline && g.Uname.Contains(uname))).SelectMany(g=>g.Uname);
        }
        

        // PUT: api/GamerSearch/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGamer(long id, Gamer gamer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gamer.Id)
            {
                return BadRequest();
            }

            db.Entry(gamer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GamerExists(long id)
        {
            return db.Gamers.Count(e => e.Id == id) > 0;
        }
    }
}