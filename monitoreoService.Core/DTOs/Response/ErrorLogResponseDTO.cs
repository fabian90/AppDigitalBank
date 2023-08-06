using System.ComponentModel.DataAnnotations;

namespace monitoreo.Core.DTOs.Response
{
    public class ErrorLogResponseDTO
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required]
        public string? Mensaje { get; set; }
        [Required]
        public string? Detalles { get; set; }
    }
}
