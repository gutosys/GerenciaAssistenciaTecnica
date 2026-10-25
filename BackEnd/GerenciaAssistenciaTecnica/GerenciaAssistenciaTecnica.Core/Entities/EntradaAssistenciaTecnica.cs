using System;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class EntradaAssistenciaTecnica : BaseEntity
    {
        public int? PessoaFisicaId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }

        public int? PessoaJuridicaId { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }

        public int? ClienteAssociadoId { get; set; }
        public ClienteAssociado ClienteAssociado { get; set; }


        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public string NumeroRemessa { get; set; }
        public string NumeroNF { get; set; }
        public int? MaquinaId { get; set; }
        public Maquina Maquina { get; set; }
        public string NumeroSerie { get; set; }
        public string NumeroComprovanteCompra { get; set; }        

        public bool TrocaJaEfetuada { get; set; }

        public string NumeroProtocoloTroca { get; set; }

        public string CodigoRastreio { get; set; }

        public List<EntradaAssistenciaAcessorio> EntradaAssistenciaAcessorios { get; set; }
        public List<EntradaAssistenciaDocumento> EntradaAssistenciaDocumentos { get; set; }

        public List<EntradaAssistenciaDescricao> EntradaAssistenciaDescricoes { get; set; }        

        public int EntradaAssistenciaStatusId { get; set; }
        public EntradaAssistenciaStatus EntradaAssistenciaStatus { get; set; }        
        public int? ComprovanteCompraId { get; set; }
        public ComprovanteCompra ComprovanteCompras { get; set; }
        public string NS { get; set; }
        public DateTime DataEntrada { get; set; }
        public int? EntreguePorId { get; set; }
        public EntreguePor EntreguePor { get; set; }
        public int? Revenda { get; set; }        
    }
}
