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
    public class mex_estadosController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/mex_estados
        public IQueryable<mex_estados> Getmex_estados()
        {
            return db.mex_estados;
        }

        // GET: api/mex_estados/5
        [ResponseType(typeof(mex_estados))]
        public IHttpActionResult Getmex_estados(int id)
        {
            mex_estados mex_estados = db.mex_estados.Find(id);
            if (mex_estados == null)
            {
                return NotFound();
            }

            return Ok(mex_estados);
        }

        // PUT: api/mex_estados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmex_estados(int id, mex_estados mex_estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mex_estados.id_estado)
            {
                return BadRequest();
            }

            db.Entry(mex_estados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mex_estadosExists(id))
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

        // POST: api/mex_estados
        [ResponseType(typeof(mex_estados))]
        public IHttpActionResult Postmex_estados(mex_estados mex_estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mex_estados.Add(mex_estados);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (mex_estadosExists(mex_estados.id_estado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mex_estados.id_estado }, mex_estados);
        }

        // DELETE: api/mex_estados/5
        [ResponseType(typeof(mex_estados))]
        public IHttpActionResult Deletemex_estados(int id)
        {
            mex_estados mex_estados = db.mex_estados.Find(id);
            if (mex_estados == null)
            {
                return NotFound();
            }

            db.mex_estados.Remove(mex_estados);
            db.SaveChanges();

            return Ok(mex_estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mex_estadosExists(int id)
        {
            return db.mex_estados.Count(e => e.id_estado == id) > 0;
        }
    }
}