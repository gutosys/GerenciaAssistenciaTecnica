namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class ClienteAssociado : BaseEntity
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int PessoaJuridicaId { get; set; }

        public PessoaJuridica PessoaJuridica { get; set; }
    }
}
