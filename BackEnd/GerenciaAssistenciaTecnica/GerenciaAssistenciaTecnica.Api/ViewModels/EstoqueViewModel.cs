namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class EstoqueViewModel
    {
        public int? Id { get; set; }
        public int ComponenteId { get; set; }
        public string ComponenteDes { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
