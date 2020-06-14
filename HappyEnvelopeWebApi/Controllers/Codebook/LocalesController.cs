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
using HappyEnvelopeWebApi.Models.Codebook;

namespace HappyEnvelopeWebApi.Controllers.Codebook
{
    public class LocalesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Locales
        public IQueryable<Locale> GetLocales()
        {
            return db.Locales;
        }

        // GET: api/Locales/5
        [ResponseType(typeof(Locale))]
        public IHttpActionResult GetLocale(int id)
        {
            Locale locale = db.Locales.Find(id);
            if (locale == null)
            {
                return NotFound();
            }

            return Ok(locale);
        }

        // PUT: api/Locales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLocale(int id, Locale locale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locale.id)
            {
                return BadRequest();
            }

            db.Entry(locale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocaleExists(id))
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

        // POST: api/Locales
        [ResponseType(typeof(Locale))]
        public IHttpActionResult PostLocale(Locale locale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Locales.Add(locale);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = locale.id }, locale);
        }

        // DELETE: api/Locales/5
        [ResponseType(typeof(Locale))]
        public IHttpActionResult DeleteLocale(int id)
        {
            Locale locale = db.Locales.Find(id);
            if (locale == null)
            {
                return NotFound();
            }

            db.Locales.Remove(locale);
            db.SaveChanges();

            return Ok(locale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocaleExists(int id)
        {
            return db.Locales.Count(e => e.id == id) > 0;
        }
    }
}