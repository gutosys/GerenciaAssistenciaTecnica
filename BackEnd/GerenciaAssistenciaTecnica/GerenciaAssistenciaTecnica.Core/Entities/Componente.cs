namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Componente : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoVendaAutorizada { get; set; }
    }
}
