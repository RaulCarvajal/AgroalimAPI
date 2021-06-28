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
    public class municipiosController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/municipios
        public IQueryable<municipios> Getmunicipios()
        {
            return db.municipios;
        }

        // GET: api/municipios/5
        [ResponseType(typeof(municipios))]
        public IHttpActionResult Getmunicipios(int id)
        {
            municipios municipios = db.municipios.Find(id);
            if (municipios == null)
            {
                return NotFound();
            }

            return Ok(municipios);
        }

        // PUT: api/municipios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmunicipios(int id, municipios municipios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != municipios.id_municipio)
            {
                return BadRequest();
            }

            db.Entry(municipios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!municipiosExists(id))
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

        // POST: api/municipios
        [ResponseType(typeof(municipios))]
        public IHttpActionResult Postmunicipios(municipios municipios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.municipios.Add(municipios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (municipiosExists(municipios.id_municipio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = municipios.id_municipio }, municipios);
        }

        // DELETE: api/municipios/5
        [ResponseType(typeof(municipios))]
        public IHttpActionResult Deletemunicipios(int id)
        {
            municipios municipios = db.municipios.Find(id);
            if (municipios == null)
            {
                return NotFound();
            }

            db.municipios.Remove(municipios);
            db.SaveChanges();

            return Ok(municipios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool municipiosExists(int id)
        {
            return db.municipios.Count(e => e.id_municipio == id) > 0;
        }
    }
}