namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int CidadeId { get; set; }        
        public int EstadoId { get; set; }        
    }
}
