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
    public class admin_empresasController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/admin_empresas
        public IQueryable<empresas> Getempresas()
        {
            return db.empresas;
        }

        // GET: api/admin_empresas/5
        [ResponseType(typeof(empresas))]
        public IHttpActionResult Getempresas(int id)
        {
            empresas empresas = db.empresas.Find(id);
            if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        // PUT: api/admin_empresas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putempresas(int id, empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresas.id_empresa)
            {
                return BadRequest();
            }

            db.Entry(empresas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!empresasExists(id))
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

        // POST: api/admin_empresas
        [ResponseType(typeof(empresas))]
        public IHttpActionResult Postempresas(empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.empresas.Add(empresas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empresas.id_empresa }, empresas);
        }

        // DELETE: api/admin_empresas/5
        [ResponseType(typeof(empresas))]
        public IHttpActionResult Deleteempresas(int id)
        {
            empresas empresas = db.empresas.Find(id);
            if (empresas == null)
            {
                return NotFound();
            }

            db.empresas.Remove(empresas);
            db.SaveChanges();

            return Ok(empresas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool empresasExists(int id)
        {
            return db.empresas.Count(e => e.id_empresa == id) > 0;
        }
    }
}