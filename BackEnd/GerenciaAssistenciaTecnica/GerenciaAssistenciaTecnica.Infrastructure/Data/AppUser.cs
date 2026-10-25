using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciaAssistenciaTecnica.Infrastructure.Data
{   
    public partial class AppUser : BaseEntity
    {
        [Required()]
        [Key()]
        public Guid UserId { get; set; }

        [Required()]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required()]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
