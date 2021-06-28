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

namespace AgroalimAPI.Controllers.Opciones
{
    public class admin_opcionesController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/admin_opciones/:fkidp POR PREGUNTA
        public IQueryable<opciones> Getopciones(int id)
        {
            return db.opciones.Where( a => a.fk_id_pregunta == id);
        }

        // GET: api/admin_opciones/5
        /*[ResponseType(typeof(opciones))]
        public IHttpActionResult Getopciones(int id)
        {
            opciones opciones = db.opciones.Find(id);
            if (opciones == null)
            {
                return NotFound();
            }

            return Ok(opciones);
        }*/

        // PUT: api/admin_opciones/5 
        [ResponseType(typeof(void))]
        public IHttpActionResult Putopciones(int id, opciones opciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opciones.id_opcion)
            {
                return BadRequest();
            }

            db.Entry(opciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!opcionesExists(id))
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

        // POST: api/admin_opciones
        [ResponseType(typeof(opciones))]
        public IHttpActionResult Postopciones(opciones opciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.opciones.Add(opciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = opciones.id_opcion }, opciones);
        }

        // DELETE: api/admin_opciones/5
        [ResponseType(typeof(opciones))]
        public IHttpActionResult Deleteopciones(int id)
        {
            opciones opciones = db.opciones.Find(id);
            if (opciones == null)
            {
                return NotFound();
            }

            db.opciones.Remove(opciones);
            db.SaveChanges();

            return Ok(opciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool opcionesExists(int id)
        {
            return db.opciones.Count(e => e.id_opcion == id) > 0;
        }
    }
}