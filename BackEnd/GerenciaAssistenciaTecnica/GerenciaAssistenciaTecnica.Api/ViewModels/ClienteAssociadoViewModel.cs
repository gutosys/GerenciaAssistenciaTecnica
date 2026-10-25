namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class ClienteAssociadoViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public int PessoaJuridicaId{ get; set; }
        public string PessoaJuridicaDes { get; set; }
    }
}
