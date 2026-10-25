namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class EntradaAssistenciaAcessorio : BaseEntity
    {
        public int AcessorioId { get; set; }
        public Acessorio Acessorio { get; set; }

        public int EntradaAssistenciaTecnicaId { get; set; }
        public EntradaAssistenciaTecnica EntradaAssistenciaTecnica { get; set; }        
    }
}
