using AgroalimAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AgroalimAPI.Controllers.Encuestas
{
    public class admin_encuestasController : ApiController
    {
        private agroalimEntities db = new agroalimEntities();

        // GET: api/encuestas_admin
       public ObjectResult<sp_get_encuestas_table_admin_Result> Get()
        {
            return db.sp_get_encuestas_table_admin();
        }

        // GET: api/encuestas_admin/5
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

        // PUT: api/encuestas_admin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putencuestas(int id, encuestas encuesta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != encuesta.id_encuesta)
            {
                return BadRequest();
            }

            db.Entry(encuesta).State = EntityState.Modified;

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
