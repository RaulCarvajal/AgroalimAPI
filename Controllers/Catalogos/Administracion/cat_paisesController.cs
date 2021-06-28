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
    public class cat_paisesController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/cat_paises
        public IQueryable<cat_paises> Getcat_paises()
        {
            return db.cat_paises;
        }

        // GET: api/cat_paises/5
        [ResponseType(typeof(cat_paises))]
        public IHttpActionResult Getcat_paises(int id)
        {
            cat_paises cat_paises = db.cat_paises.Find(id);
            if (cat_paises == null)
            {
                return NotFound();
            }

            return Ok(cat_paises);
        }

        // PUT: api/cat_paises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcat_paises(int id, cat_paises cat_paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cat_paises.id_pais)
            {
                return BadRequest();
            }

            db.Entry(cat_paises).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_paisesExists(id))
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

        // POST: api/cat_paises
        [ResponseType(typeof(cat_paises))]
        public IHttpActionResult Postcat_paises(cat_paises cat_paises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cat_paises.Add(cat_paises);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cat_paisesExists(cat_paises.id_pais))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cat_paises.id_pais }, cat_paises);
        }

        // DELETE: api/cat_paises/5
        [ResponseType(typeof(cat_paises))]
        public IHttpActionResult Deletecat_paises(int id)
        {
            cat_paises cat_paises = db.cat_paises.Find(id);
            if (cat_paises == null)
            {
                return NotFound();
            }

            db.cat_paises.Remove(cat_paises);
            db.SaveChanges();

            return Ok(cat_paises);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cat_paisesExists(int id)
        {
            return db.cat_paises.Count(e => e.id_pais == id) > 0;
        }
    }
}