namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class ComponenteViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoVendaAutorizada { get; set; }
    }
}
