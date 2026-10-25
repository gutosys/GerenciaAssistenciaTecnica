namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class PessoaFisica : BaseEntity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }        
    }
}
