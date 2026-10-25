using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Estado : BaseEntity
    {
        public string Descricao { get; set; }

        public string UF { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}
