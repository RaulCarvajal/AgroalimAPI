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
    public class admin_contactosController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/admin_contactos
        public IQueryable<contactos> Getcontactos()
        {
            return db.contactos;
        }

        // GET: api/admin_contactos/5
        [ResponseType(typeof(contactos))]
        public IHttpActionResult Getcontactos(int id)
        {
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return NotFound();
            }

            return Ok(contactos);
        }

        // PUT: api/admin_contactos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcontactos(int id, contactos contactos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactos.id_contacto)
            {
                return BadRequest();
            }

            db.Entry(contactos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactosExists(id))
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

        // POST: api/admin_contactos
        [ResponseType(typeof(contactos))]
        public IHttpActionResult Postcontactos(contactos contactos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contactos.Add(contactos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactos.id_contacto }, contactos);
        }

        // DELETE: api/admin_contactos/5
        [ResponseType(typeof(contactos))]
        public IHttpActionResult Deletecontactos(int id)
        {
            contactos contactos = db.contactos.Find(id);
            if (contactos == null)
            {
                return NotFound();
            }

            db.contactos.Remove(contactos);
            db.SaveChanges();

            return Ok(contactos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool contactosExists(int id)
        {
            return db.contactos.Count(e => e.id_contacto == id) > 0;
        }
    }
}