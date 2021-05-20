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

namespace AgroalimAPI.Controllers.Catalogos
{
    public class cat_puestosController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/cat_puestos
        public IQueryable<cat_puestos> Getcat_puestos()
        {
            return db.cat_puestos;
        }

        // GET: api/cat_puestos/5
        [ResponseType(typeof(cat_puestos))]
        public IHttpActionResult Getcat_puestos(int id)
        {
            cat_puestos cat_puestos = db.cat_puestos.Find(id);
            if (cat_puestos == null)
            {
                return NotFound();
            }

            return Ok(cat_puestos);
        }

        // PUT: api/cat_puestos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcat_puestos(int id, cat_puestos cat_puestos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cat_puestos.id_puesto)
            {
                return BadRequest();
            }

            db.Entry(cat_puestos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_puestosExists(id))
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

        // POST: api/cat_puestos
        [ResponseType(typeof(cat_puestos))]
        public IHttpActionResult Postcat_puestos(cat_puestos cat_puestos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cat_puestos.Add(cat_puestos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cat_puestos.id_puesto }, cat_puestos);
        }

        // DELETE: api/cat_puestos/5
        [ResponseType(typeof(cat_puestos))]
        public IHttpActionResult Deletecat_puestos(int id)
        {
            cat_puestos cat_puestos = db.cat_puestos.Find(id);
            if (cat_puestos == null)
            {
                return NotFound();
            }

            db.cat_puestos.Remove(cat_puestos);
            db.SaveChanges();

            return Ok(cat_puestos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cat_puestosExists(int id)
        {
            return db.cat_puestos.Count(e => e.id_puesto == id) > 0;
        }
    }
}