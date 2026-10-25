namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Cliente : BaseEntity
    {        
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public int? EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        //F - Física | J - Jurídica
        public string TipoPessoa { get; set; }
    }
}
