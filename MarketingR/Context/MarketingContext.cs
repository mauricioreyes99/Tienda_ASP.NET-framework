using MarketingR.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MarketingR.Context
{
    public class MarketingContext : DbContext
    {
        public MarketingContext() : base("name=MarketingContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipo_documento> Tipo_documentos { get; set; }
        


        public System.Data.Entity.DbSet<MarketingR.Models.Proveedor> Proveedores { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.ProveedorProducto> ProveedorProductos { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Orden> Ordenes { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.Rol> Roles { get; set; }

        public System.Data.Entity.DbSet<MarketingR.Models.AdministracionRol> AdministracionRols { get; set; }
    }
}