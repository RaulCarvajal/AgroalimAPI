using AgroalimAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgroalimAPI.Controllers.Encuestas
{
    public class encuestasusuariosController : ApiController
    {

        private agroalimEntities db = new agroalimEntities();

        // GET: api/encuestas
        public ObjectResult<sp_get_encuestas_usuario_by_fecregdesc_Result> Getencuestas()
        {
            return db.sp_get_encuestas_usuario_by_fecregdesc();
        }

    }
}
