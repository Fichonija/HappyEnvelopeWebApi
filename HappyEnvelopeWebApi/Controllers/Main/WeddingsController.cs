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
using HappyEnvelopeWebApi.Models;
using HappyEnvelopeWebApi.Models.Main;

namespace HappyEnvelopeWebApi.Controllers.Main
{
    public class WeddingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Weddings
        public IQueryable<Wedding> GetWeddings()
        {
            return db.Weddings.Include(w => w.calculation).Include(w => w.gift);
        }

        // GET: api/Weddings/5
        [ResponseType(typeof(Wedding))]
        public IHttpActionResult GetWedding(int id)
        {
            Wedding wedding = db.Weddings.Where(w => w.id == id)
                .Include(w => w.calculation)
                .Include(w => w.gift)
                .FirstOrDefault();
            if (wedding == null)
            {
                return NotFound();
            }

            return Ok(wedding);
        }

        // PUT: api/Weddings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWedding(int id, Wedding wedding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wedding.id)
            {
                return BadRequest();
            }

            db.Entry(wedding).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeddingExists(id))
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

        // POST: api/Weddings
        [ResponseType(typeof(Wedding))]
        public IHttpActionResult PostWedding(Wedding wedding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Calculation calculation = db.Calculations.Find(wedding.calculation_id);
            wedding.calculation = calculation;
            Gift gift = db.Gifts.Find(wedding.gift_id);
            wedding.gift = gift;

            db.Weddings.Add(wedding);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wedding.id }, wedding);
        }

        // DELETE: api/Weddings/5
        [ResponseType(typeof(Wedding))]
        public IHttpActionResult DeleteWedding(int id)
        {
            Wedding wedding = db.Weddings.Find(id);
            if (wedding == null)
            {
                return NotFound();
            }

            db.Weddings.Remove(wedding);
            db.SaveChanges();

            return Ok(wedding);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeddingExists(int id)
        {
            return db.Weddings.Count(e => e.id == id) > 0;
        }
    }
}