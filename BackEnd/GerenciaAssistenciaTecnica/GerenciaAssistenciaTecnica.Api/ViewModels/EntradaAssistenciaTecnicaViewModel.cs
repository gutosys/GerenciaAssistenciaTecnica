using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class EntradaAssistenciaTecnicaViewModel
    {
        public int? Id { get; set; }
        public string TipoPessoa { get; set; }
        public int? PessoaFisica { get; set; }

        public string Nome { get; set; }

        public int? PessoaJuridica { get; set; }
        public int? ClienteAssociado { get; set; }

        public int? Funcionario { get; set; }

        public string FuncionarioDesc { get; set; }

        public string NumeroProtocoloTroca { get; set; }

        public string NS { get; set; }

        public string CodigoRastreio { get; set; }

        public string NumeroRemessa { get; set; }
        public string NumeroNF { get; set; }

        public bool TrocaJaEfetuada { get; set; }

        public string NumeroComprovanteCompra { get; set; }

        public int? ComprovanteCompra { get; set; }

        public int? EntreguePor { get; set; }

        public int? Maquina { get; set; }

        public string MaquinaDesc { get; set; }

        public string NumeroSerie { get; set; }
        public string Acessorios { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataEntrada { get; set; }

        public int EntradaAssistenciaStatusId { get; set; }

        public int? Revenda { get; set; }

        public List<int> AcessorioList { get; set; }
        //public ICollection<EntradaAssistenciaAcessorioViewModel> EntradaAssistenciaAcessorioList { get; set; }

        public ICollection<EntradaAssistenciaDocumentoViewModel> EntradaAssistenciaDocumentoList { get; set; }

        public ICollection<EntradaAssistenciaDescricaoViewModel> EntradaAssistenciaDescricaoList { get; set; }
    }
}
