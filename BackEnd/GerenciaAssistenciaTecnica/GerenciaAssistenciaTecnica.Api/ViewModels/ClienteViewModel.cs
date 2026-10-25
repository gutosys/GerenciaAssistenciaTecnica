using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public int EnderecoId { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
