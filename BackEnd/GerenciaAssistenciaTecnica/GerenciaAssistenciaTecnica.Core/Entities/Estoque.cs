namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Estoque : BaseEntity
    {
        public int ComponenteId { get; set; }
        public Componente Componente { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
