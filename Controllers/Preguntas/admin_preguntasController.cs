using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgroalimAPI.Models;

namespace AgroalimAPI.Controllers.Preguntas
{
    public class admin_preguntasController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/admin_preguntas
        public ObjectResult<sp_get_preguntas_dash_encuesta_admin_Result> Get(int id)
        {
            return db.sp_get_preguntas_dash_encuesta_admin(id);
        }

        // PUT: api/admin_preguntas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpreguntas(int id, preguntas preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntas.id_pregunta)
            {
                return BadRequest();
            }

            db.Entry(preguntas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!preguntasExists(id))
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

        // POST: api/admin_preguntas
        [ResponseType(typeof(preguntas))]
        public IHttpActionResult Postpreguntas(preguntas preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.preguntas.Add(preguntas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preguntas.id_pregunta }, preguntas);
        }

        // DELETE: api/admin_preguntas/5
        [ResponseType(typeof(preguntas))]
        public IHttpActionResult Deletepreguntas(int id)
        {
            preguntas preguntas = db.preguntas.Find(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            db.preguntas.Remove(preguntas);
            db.SaveChanges();

            return Ok(preguntas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool preguntasExists(int id)
        {
            return db.preguntas.Count(e => e.id_pregunta == id) > 0;
        }
    }
}