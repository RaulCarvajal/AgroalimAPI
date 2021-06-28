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
using AgroalimAPI.Controllers.ClasesEspeciales;
using AgroalimAPI.Models;

namespace AgroalimAPI.Controllers.Encuestas
{
    public class preguntasController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();



        // GET: api/preguntas
        public IQueryable<preguntas> Getpreguntas()
        {
            return db.preguntas;
        }

        // GET: api/preguntas/5
        [ResponseType(typeof(preguntas))]
        public IHttpActionResult Getpreguntas(int id)
        {
            preguntas preguntas = db.preguntas.Find(id);
            if (preguntas == null)
            {
                return NotFound();
            }

            return Ok(preguntas);
        }

        // PUT: api/preguntas/5
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

        // POST: api/preguntas
        [ResponseType(typeof(preguntas))]
        public IHttpActionResult Postpreguntas(preguntaReq preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            preguntas pregunta = new preguntas();
            pregunta.pregunta = preguntas.pregunta;
            pregunta.fk_id_encuesta = preguntas.fk_id_encuesta;
            pregunta.fecha_registro = DateTime.Now;
            pregunta.estatus = true;

            pregunta = db.preguntas.Add(pregunta);

            foreach(opciones o in preguntas.opciones)
            {
                o.fk_id_pregunta = pregunta.id_pregunta;
                db.opciones.Add(o);
            }

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pregunta.id_pregunta }, pregunta);
        }

        // DELETE: api/preguntas/5
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