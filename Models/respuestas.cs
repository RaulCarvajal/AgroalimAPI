//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgroalimAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class respuestas
    {
        public int id_respuesta { get; set; }
        public Nullable<int> fk_id_pregunta { get; set; }
        public Nullable<int> fk_id_opcion { get; set; }
        public Nullable<int> fk_id_contacto { get; set; }
        public Nullable<int> fk_id_empresa { get; set; }
        public Nullable<System.DateTime> fecha_respuesta { get; set; }
    }
}