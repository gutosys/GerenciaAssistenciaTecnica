using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class EntradaAssistenciaDescricaoViewModel
    {
        public int Id { get; set; }
        public int EntradaAssistenciaStatus { get; set; }
        public int EntradaAssistenciaTecnicaId { get; set; }        
        public string DataGravacao { get; set; }
    }
}
