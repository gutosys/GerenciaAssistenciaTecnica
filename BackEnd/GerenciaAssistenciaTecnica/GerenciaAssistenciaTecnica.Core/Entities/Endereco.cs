namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int? CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public int? EstadoId { get; set; }
        public Estado Estado { get; set; }        
    }
}
