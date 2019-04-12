using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Orden
    {
        [Key]
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha_Orden { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        public int ClienteID { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}