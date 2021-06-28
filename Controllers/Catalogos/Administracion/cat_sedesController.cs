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
using AgroalimAPI.Models;

namespace AgroalimAPI.Controllers.Catalogos.Administracion
{
    public class cat_sedesController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/cat_sedes
        public IQueryable<cat_sedes> Getcat_sedes()
        {
            return db.cat_sedes;
        }

        // GET: api/cat_sedes/5
        [ResponseType(typeof(cat_sedes))]
        public IHttpActionResult Getcat_sedes(int id)
        {
            cat_sedes cat_sedes = db.cat_sedes.Find(id);
            if (cat_sedes == null)
            {
                return NotFound();
            }

            return Ok(cat_sedes);
        }

        // PUT: api/cat_sedes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcat_sedes(int id, cat_sedes cat_sedes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cat_sedes.id_cat_sede)
            {
                return BadRequest();
            }

            db.Entry(cat_sedes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_sedesExists(id))
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

        // POST: api/cat_sedes
        [ResponseType(typeof(cat_sedes))]
        public IHttpActionResult Postcat_sedes(cat_sedes cat_sedes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cat_sedes.Add(cat_sedes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cat_sedes.id_cat_sede }, cat_sedes);
        }

        // DELETE: api/cat_sedes/5
        [ResponseType(typeof(cat_sedes))]
        public IHttpActionResult Deletecat_sedes(int id)
        {
            cat_sedes cat_sedes = db.cat_sedes.Find(id);
            if (cat_sedes == null)
            {
                return NotFound();
            }

            db.cat_sedes.Remove(cat_sedes);
            db.SaveChanges();

            return Ok(cat_sedes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cat_sedesExists(int id)
        {
            return db.cat_sedes.Count(e => e.id_cat_sede == id) > 0;
        }
    }
}