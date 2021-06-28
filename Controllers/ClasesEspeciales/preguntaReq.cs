using AgroalimAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgroalimAPI.Controllers.ClasesEspeciales
{
    public partial class preguntaReq
    {
        public int id_pregunta { get; set; }
        public string pregunta { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<bool> estatus { get; set; }
        public Nullable<int> fk_id_encuesta { get; set; }
        public opciones[] opciones { get; set; }
    }
}