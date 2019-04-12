using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketingR.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombres")]
        public string Nombre_Cliente { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        public string Apellido_Cliente { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Display(Name = "telefono")]
        public string Movil { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Direccion { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debes llenar el campo {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} debe constar entre {2} y {1} caracteres", MinimumLength = 5)]
        public string Documento { get; set; }

      
        public int Id_tipoDocumento { get; set; }

        public virtual Tipo_documento Tipo_Documento { get; set; }

        public ICollection<Orden> Ordenes { get; set; }


    }
}