using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Dtos
{
     public class AutenticacionDto
    {
        [Required(ErrorMessage = "El campo nombre usuario es obligatorio")]
        public string username { get; set; }
        [Required(ErrorMessage = "El campo password es obligatorio")]
        public string password { get; set; }
    }
}
