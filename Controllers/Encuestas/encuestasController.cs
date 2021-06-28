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

namespace AgroalimAPI.Controllers.Encuestas
{
    public class encuestasController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/encuestas
        public IQueryable<encuestas> Getencuestas()
        {
            return db.encuestas;
        }

        // GET: api/encuestas/5
        [ResponseType(typeof(encuestas))]
        public IHttpActionResult Getencuestas(int id)
        {
            encuestas encuestas = db.encuestas.Find(id);
            if (encuestas == null)
            {
                return NotFound();
            }

            return Ok(encuestas);
        }

        // PUT: api/encuestas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putencuestas(int id, encuestas encuestas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != encuestas.id_encuesta)
            {
                return BadRequest();
            }

            db.Entry(encuestas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!encuestasExists(id))
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

        // POST: api/encuestas
        [ResponseType(typeof(encuestas))]
        public IHttpActionResult Postencuestas(encuestas encuestas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            encuestas.fecha_registro = DateTime.Today;
            db.encuestas.Add(encuestas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = encuestas.id_encuesta }, encuestas);
        }

        // DELETE: api/encuestas/5
        [ResponseType(typeof(encuestas))]
        public IHttpActionResult Deleteencuestas(int id)
        {
            encuestas encuestas = db.encuestas.Find(id);
            if (encuestas == null)
            {
                return NotFound();
            }

            db.encuestas.Remove(encuestas);
            db.SaveChanges();

            return Ok(encuestas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool encuestasExists(int id)
        {
            return db.encuestas.Count(e => e.id_encuesta == id) > 0;
        }
    }
}