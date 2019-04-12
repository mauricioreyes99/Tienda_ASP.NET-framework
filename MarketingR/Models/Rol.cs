using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        [Display(Name ="Rol")]
        public string RolName { get; set; }

        public virtual ICollection<AdministracionRol> Rols { get; set; }
    }
}