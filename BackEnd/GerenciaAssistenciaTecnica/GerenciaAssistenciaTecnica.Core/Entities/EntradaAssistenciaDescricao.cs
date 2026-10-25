using System;

namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class EntradaAssistenciaDescricao : BaseEntity
    {
        public string Descricao { get; set; }

        public int EntradaAssistenciaStatusId { get; set; }
        public EntradaAssistenciaStatus EntradaAssistenciaStatus { get; set; }

        public int EntradaAssistenciaTecnicaId { get; set; }

        public EntradaAssistenciaTecnica EntradaAssistenciaTecnica { get; set; }

        public DateTime DataGravacao { get; set; }
    }
}
