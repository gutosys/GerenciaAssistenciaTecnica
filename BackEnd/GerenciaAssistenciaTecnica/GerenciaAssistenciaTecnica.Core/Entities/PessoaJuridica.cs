namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class PessoaJuridica : BaseEntity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public string IE { get; set; }
        
        public int RegimeTributarioId { get; set; }
        public RegimeTributario RegimeTributario { get; set; }        
    }
}
