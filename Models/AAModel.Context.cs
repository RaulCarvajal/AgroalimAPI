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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class agroalimEntities : DbContext
    {
        public agroalimEntities()
            : base("name=agroalimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administradores> administradores { get; set; }
        public virtual DbSet<cat_certificaciones> cat_certificaciones { get; set; }
        public virtual DbSet<cat_detalle_ventas> cat_detalle_ventas { get; set; }
        public virtual DbSet<cat_industry_levers> cat_industry_levers { get; set; }
        public virtual DbSet<cat_nivel_ventas> cat_nivel_ventas { get; set; }
        public virtual DbSet<cat_org_empresarial> cat_org_empresarial { get; set; }
        public virtual DbSet<cat_paises> cat_paises { get; set; }
        public virtual DbSet<cat_partnership> cat_partnership { get; set; }
        public virtual DbSet<cat_posicionamiento> cat_posicionamiento { get; set; }
        public virtual DbSet<cat_puestos> cat_puestos { get; set; }
        public virtual DbSet<cat_sectores> cat_sectores { get; set; }
        public virtual DbSet<cat_sectores_atendidos> cat_sectores_atendidos { get; set; }
        public virtual DbSet<cat_sedes> cat_sedes { get; set; }
        public virtual DbSet<cat_softwares> cat_softwares { get; set; }
        public virtual DbSet<cat_tamano_empresas> cat_tamano_empresas { get; set; }
        public virtual DbSet<cat_tecnologias> cat_tecnologias { get; set; }
        public virtual DbSet<cat_tipo_empresas> cat_tipo_empresas { get; set; }
        public virtual DbSet<cat_tipo_prod> cat_tipo_prod { get; set; }
        public virtual DbSet<cat_value_drivers> cat_value_drivers { get; set; }
        public virtual DbSet<certificaciones_empresas> certificaciones_empresas { get; set; }
        public virtual DbSet<coberturas> coberturas { get; set; }
        public virtual DbSet<contactos> contactos { get; set; }
        public virtual DbSet<direcciones> direcciones { get; set; }
        public virtual DbSet<emp_sede> emp_sede { get; set; }
        public virtual DbSet<empresas> empresas { get; set; }
        public virtual DbSet<encuestas> encuestas { get; set; }
        public virtual DbSet<estatificacion_empresa> estatificacion_empresa { get; set; }
        public virtual DbSet<marca_nivel> marca_nivel { get; set; }
        public virtual DbSet<mex_estados> mex_estados { get; set; }
        public virtual DbSet<municipios> municipios { get; set; }
        public virtual DbSet<opciones> opciones { get; set; }
        public virtual DbSet<orgs_emp> orgs_emp { get; set; }
        public virtual DbSet<preguntas> preguntas { get; set; }
        public virtual DbSet<prod_vald_ind> prod_vald_ind { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<respuestas> respuestas { get; set; }
        public virtual DbSet<software_empresa> software_empresa { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tecnologia_producto> tecnologia_producto { get; set; }
        public virtual DbSet<solicitudes> solicitudes { get; set; }
    
        public virtual ObjectResult<sp_get_encuestas_table_admin_Result> sp_get_encuestas_table_admin()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_encuestas_table_admin_Result>("sp_get_encuestas_table_admin");
        }
    
        public virtual ObjectResult<sp_get_preguntas_dash_encuesta_admin_Result> sp_get_preguntas_dash_encuesta_admin(Nullable<int> fkide)
        {
            var fkideParameter = fkide.HasValue ?
                new ObjectParameter("fkide", fkide) :
                new ObjectParameter("fkide", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_preguntas_dash_encuesta_admin_Result>("sp_get_preguntas_dash_encuesta_admin", fkideParameter);
        }
    
        public virtual ObjectResult<sp_get_encuestas_usuario_by_fecregdesc_Result> sp_get_encuestas_usuario_by_fecregdesc()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_get_encuestas_usuario_by_fecregdesc_Result>("sp_get_encuestas_usuario_by_fecregdesc");
        }
    }
}
