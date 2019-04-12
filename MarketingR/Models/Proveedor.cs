using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Proveedor
    {
        [Key]
        public int ProveedorID { get; set; }

        [Required(ErrorMessage ="Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage ="El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength =3)]
        [Display(Name ="Nombre del proveedor")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre del contacto")]
        public string Nombre_Contacto { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido del contacto")]
        public string Apellido_Contacto { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Display(Name = "telefono")]
        public string Movil { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<ProveedorProducto> ProveedorProductos { get; set; }
    }
}