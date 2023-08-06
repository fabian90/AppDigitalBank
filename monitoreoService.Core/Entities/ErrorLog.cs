using monitoreo.Commons.Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace monitoreo.Core.Entities
{
    public partial class ErrorLog : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public DateTime FechaRegistro { get; set; }  
        public string Mensaje { get; set; }     
        public string Detalles { get; set; }

    }
}
