using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Dtos
{
    public class ErrorLogDto
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required]
        public string Mensaje { get; set; }
        [Required]
        public string Detalles { get; set; }
    }
}
