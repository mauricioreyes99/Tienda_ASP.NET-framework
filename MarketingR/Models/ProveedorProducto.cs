using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class ProveedorProducto
    {
        [Key]
        public int ProveedorProductoID { get; set; }

        public int ProveedorID { get; set; }

        public int Id_producto { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual Producto Producto { get; set; }
    }
}