using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class AdministracionRol
    {
        [Key]
        public int AdminRolID { get; set; }

        public int Id_empleado { get; set; }

        public virtual Empleado Empleado { get; set; }

        public int RolID { get; set; }

        public virtual Rol Rol { get; set; }
    }
}