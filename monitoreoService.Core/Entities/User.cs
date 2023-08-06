using monitoreo.Commons.Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace monitoreo.Core.Entities
{
    public partial class User : BaseEntity
    {
       
        public string UserName { get; set; }        
        public string Password { get; set; }
    }
}
