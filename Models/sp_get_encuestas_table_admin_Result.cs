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
    
    public partial class sp_get_encuestas_table_admin_Result
    {
        public int id_encuesta { get; set; }
        public string nombre { get; set; }
        public Nullable<double> eversion { get; set; }
        public Nullable<bool> estatus { get; set; }
        public Nullable<int> preguntas { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
    }
}
