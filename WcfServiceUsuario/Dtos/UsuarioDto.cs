using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una fecha válida")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo Sexo es obligatorio")]
        [StringLength(1, ErrorMessage = "El campo Sexo debe tener una longitud de 1 carácter")]
        public string Sexo { get; set; }
    }
}
