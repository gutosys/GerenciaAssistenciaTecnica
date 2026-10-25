using System;

namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class MaquinaCliente : BaseEntity
    {
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public int MaquinaId { get; set; }
        public Maquina Maquina { get; set; }

        public string NumeroSerie { get; set; }

        public DateTime? DataInicioGarantia { get; set; }
        public DateTime? DataFimGarantia { get; set; }

        public bool TemGarantia { get; set; }

        public bool ChecaGarantia()
        {
            return DataFimGarantia > DataInicioGarantia;
        }
    }
}
