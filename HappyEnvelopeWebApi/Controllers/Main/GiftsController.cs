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
    public class GiftsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Gifts
        public IQueryable<Gift> GetGifts()
        {
            return db.Gifts;
        }

        // GET: api/Gifts/5
        [ResponseType(typeof(Gift))]
        public IHttpActionResult GetGift(int id)
        {
            Gift gift = db.Gifts.Find(id);
            if (gift == null)
            {
                return NotFound();
            }

            return Ok(gift);
        }

        // PUT: api/Gifts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGift(int id, Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gift.id)
            {
                return BadRequest();
            }

            db.Entry(gift).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftExists(id))
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

        // POST: api/Gifts
        [ResponseType(typeof(Gift))]
        public IHttpActionResult PostGift(Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gifts.Add(gift);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gift.id }, gift);
        }

        // DELETE: api/Gifts/5
        [ResponseType(typeof(Gift))]
        public IHttpActionResult DeleteGift(int id)
        {
            Gift gift = db.Gifts.Find(id);
            if (gift == null)
            {
                return NotFound();
            }

            db.Gifts.Remove(gift);
            db.SaveChanges();

            return Ok(gift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GiftExists(int id)
        {
            return db.Gifts.Count(e => e.id == id) > 0;
        }
    }
}