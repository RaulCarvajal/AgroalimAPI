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
    
    public partial class contactos
    {
        public Nullable<int> fk_id_puesto { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena { get; set; }
        public string tipo_usuario { get; set; }
        public int id_contacto { get; set; }
        public Nullable<int> estatus_registro { get; set; }
        public Nullable<int> fk_id_empresa { get; set; }
        public Nullable<bool> estado { get; set; }
    }
}
