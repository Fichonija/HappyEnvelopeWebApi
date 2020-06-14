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
using HappyEnvelopeWebApi.Models.Main;

namespace HappyEnvelopeWebApi.Controllers.Main
{
    public class CalculationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Calculations
        public IQueryable<Calculation> GetCalculations()
        {
            return db.Calculations
                .Include(c => c.salary)
                .Include(c => c.relationship)
                .Include(c => c.@event)
                .Include(c => c.locale)
                .Include(c => c.season);
        }

        // GET: api/Calculations/5
        [ResponseType(typeof(Calculation))]
        public IHttpActionResult GetCalculation(int id)
        {
            Calculation calculation = db.Calculations.Where(c => c.id == id)
                .Include(c => c.salary)
                .Include(c => c.relationship)
                .Include(c => c.@event)
                .Include(c => c.locale)
                .Include(c => c.season)
                .FirstOrDefault();
            if (calculation == null)
            {
                return NotFound();
            }

            return Ok(calculation);
        }

        // PUT: api/Calculations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalculation(int id, Calculation calculation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calculation.id)
            {
                return BadRequest();
            }

            db.Entry(calculation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculationExists(id))
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

        // POST: api/Calculations
        [ResponseType(typeof(Calculation))]
        public IHttpActionResult PostCalculation(Calculation calculation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Salary salary = db.Salaries.Find(calculation.salary_id);
            calculation.salary = salary;
            Relationship relationship = db.Relationships.Find(calculation.relationship_id);
            calculation.relationship = relationship;
            Locale locale = db.Locales.Find(calculation.locale_id);
            calculation.locale = locale;
            Event _event = db.Events.Find(calculation.event_id);
            calculation.@event = _event;
            Season season = db.Seasons.Find(calculation.season_id);
            calculation.season = season;
            db.Calculations.Add(calculation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calculation.id }, calculation);
        }

        // DELETE: api/Calculations/5
        [ResponseType(typeof(Calculation))]
        public IHttpActionResult DeleteCalculation(int id)
        {
            Calculation calculation = db.Calculations.Find(id);
            if (calculation == null)
            {
                return NotFound();
            }

            db.Calculations.Remove(calculation);
            db.SaveChanges();

            return Ok(calculation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalculationExists(int id)
        {
            return db.Calculations.Count(e => e.id == id) > 0;
        }
    }
}