namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class PessoaJuridicaViewModel
    {
        public int? Id { get; set; }
        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }

        public string IE { get; set; }

        public int TipoEmpresaId { get; set; }
        
        public int RegimeTributarioId { get; set; }        

        public int? ClienteId { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }

    public class PessoaJuridicaCreateViewModel
    {
        public int? Id { get; set; }
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string IE { get; set; }
        public int TipoEmpresaId { get; set; }
        public int RegimeTributarioId { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int? CidadeId { get; set; }
        public int? EstadoId { get; set; }
        public int? ClienteId { get; set; }
        public int? EnderecoId { get; set; }
        public string TipoPessoa { get; set; }

    }
}
