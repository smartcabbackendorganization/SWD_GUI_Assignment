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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class VaromidesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Varomides
        public IQueryable<Varomides> GetVarroemides()
        {
            return db.Varroemides;
        }

        // GET: api/Varomides/5
        [Route("[action]")]
        [ResponseType(typeof(Varomides))]
        public IHttpActionResult GetVaromides(int id)
        {
            Varomides varomides = db.Varroemides.Find(id);
            if (varomides == null)
            {
                return NotFound();
            }

            return Ok(varomides);
        }

        // PUT: api/Varomides/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVaromides(int id, Varomides varomides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != varomides.Id)
            {
                return BadRequest();
            }

            db.Entry(varomides).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaromidesExists(id))
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

        // POST: api/Varomides
        [ResponseType(typeof(Varomides))]
        public IHttpActionResult PostVaromides(Varomides varomides)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Varroemides.Add(varomides);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = varomides.Id }, varomides);
        }

        // DELETE: api/Varomides/5
        [ResponseType(typeof(Varomides))]
        public IHttpActionResult DeleteVaromides(int id)
        {
            Varomides varomides = db.Varroemides.Find(id);
            if (varomides == null)
            {
                return NotFound();
            }

            db.Varroemides.Remove(varomides);
            db.SaveChanges();

            return Ok(varomides);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VaromidesExists(int id)
        {
            return db.Varroemides.Count(e => e.Id == id) > 0;
        }
    }
}