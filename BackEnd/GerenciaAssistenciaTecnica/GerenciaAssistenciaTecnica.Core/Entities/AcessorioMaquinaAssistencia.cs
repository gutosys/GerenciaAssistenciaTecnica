namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class AcessorioMaquinaAssistencia : BaseEntity
    {
        public string Acessorio { get; set; }

        public int EntradaAssistenciaTecnicaId { get; set; }

        public EntradaAssistenciaTecnica EntradaAssistenciaTecnica { get; set; }
    }
}
