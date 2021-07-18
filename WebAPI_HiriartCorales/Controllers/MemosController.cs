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
    public class MemosController : ApiController
    {
        private AgendaPersonal db = new AgendaPersonal();

        // GET: api/Memos
        public IQueryable<Memos> GetMemos()
        {
            return db.Memos;
        }

        // GET: api/Memos/5
        [ResponseType(typeof(Memos))]
        public IHttpActionResult GetMemos(int id)
        {
            Memos memos = db.Memos.Find(id);
            if (memos == null)
            {
                return NotFound();
            }

            return Ok(memos);
        }

        // PUT: api/Memos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMemos(int id, Memos memos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memos.MemoID)
            {
                return BadRequest();
            }

            db.Entry(memos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemosExists(id))
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

        // POST: api/Memos
        [ResponseType(typeof(Memos))]
        public IHttpActionResult PostMemos(Memos memos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Memos.Add(memos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = memos.MemoID }, memos);
        }

        // DELETE: api/Memos/5
        [ResponseType(typeof(Memos))]
        public IHttpActionResult DeleteMemos(int id)
        {
            Memos memos = db.Memos.Find(id);
            if (memos == null)
            {
                return NotFound();
            }

            db.Memos.Remove(memos);
            db.SaveChanges();

            return Ok(memos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemosExists(int id)
        {
            return db.Memos.Count(e => e.MemoID == id) > 0;
        }
    }
}