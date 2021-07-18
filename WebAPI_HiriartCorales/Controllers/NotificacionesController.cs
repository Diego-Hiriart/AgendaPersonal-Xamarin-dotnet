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
    public class NotificacionesController : ApiController
    {
        private AgendaPersonal db = new AgendaPersonal();

        // GET: api/Notificaciones
        public IQueryable<Notificacions> GetNotificacions()
        {
            return db.Notificacions;
        }

        // GET: api/Notificaciones/5
        [ResponseType(typeof(Notificacions))]
        public IHttpActionResult GetNotificacions(int id)
        {
            Notificacions notificacions = db.Notificacions.Find(id);
            if (notificacions == null)
            {
                return NotFound();
            }

            return Ok(notificacions);
        }

        // PUT: api/Notificaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotificacions(int id, Notificacions notificacions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificacions.NotificacionID)
            {
                return BadRequest();
            }

            db.Entry(notificacions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificacionsExists(id))
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

        // POST: api/Notificaciones
        [ResponseType(typeof(Notificacions))]
        public IHttpActionResult PostNotificacions(Notificacions notificacions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notificacions.Add(notificacions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notificacions.NotificacionID }, notificacions);
        }

        // DELETE: api/Notificaciones/5
        [ResponseType(typeof(Notificacions))]
        public IHttpActionResult DeleteNotificacions(int id)
        {
            Notificacions notificacions = db.Notificacions.Find(id);
            if (notificacions == null)
            {
                return NotFound();
            }

            db.Notificacions.Remove(notificacions);
            db.SaveChanges();

            return Ok(notificacions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotificacionsExists(int id)
        {
            return db.Notificacions.Count(e => e.NotificacionID == id) > 0;
        }
    }
}