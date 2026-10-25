using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Funcionario : BaseEntity
    {        

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }
    }
}
