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
using WebAPI_HiriartCorales.Models;

namespace WebAPI_HiriartCorales.Controllers
{
    public class EventosController : ApiController
    {
        private AgendaPersonal db = new AgendaPersonal();

        // GET: api/Eventos
        public IQueryable<Eventoes> GetEventoes()
        {
            return db.Eventoes;
        }

        // GET: api/Eventos/5
        [ResponseType(typeof(Eventoes))]
        public IHttpActionResult GetEventoes(int id)
        {
            Eventoes eventoes = db.Eventoes.Find(id);
            if (eventoes == null)
            {
                return NotFound();
            }

            return Ok(eventoes);
        }

        // PUT: api/Eventos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventoes(int id, Eventoes eventoes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventoes.EventoID)
            {
                return BadRequest();
            }

            db.Entry(eventoes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoesExists(id))
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

        // POST: api/Eventos
        [ResponseType(typeof(Eventoes))]
        public IHttpActionResult PostEventoes(Eventoes eventoes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Eventoes.Add(eventoes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventoes.EventoID }, eventoes);
        }

        // DELETE: api/Eventos/5
        [ResponseType(typeof(Eventoes))]
        public IHttpActionResult DeleteEventoes(int id)
        {
            Eventoes eventoes = db.Eventoes.Find(id);
            if (eventoes == null)
            {
                return NotFound();
            }

            db.Eventoes.Remove(eventoes);
            db.SaveChanges();

            return Ok(eventoes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoesExists(int id)
        {
            return db.Eventoes.Count(e => e.EventoID == id) > 0;
        }
    }
}