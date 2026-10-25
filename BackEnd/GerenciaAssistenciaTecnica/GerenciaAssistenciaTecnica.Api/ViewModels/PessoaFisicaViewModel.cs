namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class PessoaFisicaViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

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

        public int EnderecoId { get; set; }

        //public int ClienteId { get; set; }

        //public ClienteViewModel Cliente { get; set; }
    }
}
