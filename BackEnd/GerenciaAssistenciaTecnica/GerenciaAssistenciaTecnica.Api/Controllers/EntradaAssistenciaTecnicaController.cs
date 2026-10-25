using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Api.ViewModels;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class EntradaAssistenciaTecnicaController : BaseApiController
    {
        private readonly IEntradaAssistenciaTecnicaService _entradaAssistenciaTecnicaService;
        private readonly INumeroSerieService _numeroSerieService;
        private readonly INSService _nsService;

        public EntradaAssistenciaTecnicaController(IEntradaAssistenciaTecnicaService entradaAssistenciaTecnicaService,
                                                   INumeroSerieService numeroSerieService,
                                                   INSService nsService)
        {
            this._entradaAssistenciaTecnicaService = entradaAssistenciaTecnicaService;
            this._numeroSerieService = numeroSerieService;
            this._nsService = nsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EntradaAssistenciaTecnicaViewModel>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allEntradaAssistenciaTecnica = await _entradaAssistenciaTecnicaService.ReadAllAsync();

            var entradaAssistenciaTecnicaList = new List<EntradaAssistenciaTecnicaViewModel>();
            foreach (var entrada in allEntradaAssistenciaTecnica)
            {
                entradaAssistenciaTecnicaList.Add(
                    new EntradaAssistenciaTecnicaViewModel
                    {
                        Id = entrada.Id,
                        //PessoaFisica = entrada.PessoaFisicaId,
                        //PessoaJuridica = entrada.PessoaJuridicaId,
                        Nome = entrada.PessoaFisica?.Nome == null ? entrada.PessoaJuridica?.RazaoSocial + " - CNPJ: " + entrada.PessoaJuridica?.Cnpj : entrada.PessoaFisica?.Nome + " - CPF: " + entrada.PessoaFisica?.Cpf,
                        MaquinaDesc = entrada.Maquina?.Modelo,                        
                        NS = entrada.NS,
                        FuncionarioDesc = entrada.Funcionario?.Nome,
                        //Funcionario = entrada.FuncionarioId,
                        NumeroRemessa = entrada.NumeroRemessa,
                        NumeroNF = entrada.NumeroNF,
                        NumeroComprovanteCompra = entrada.NumeroComprovanteCompra,
                        Maquina = entrada.MaquinaId,
                        NumeroSerie = entrada.NumeroSerie,
                        EntradaAssistenciaStatusId = entrada.EntradaAssistenciaStatusId
                        //AcessorioList = entrada.AcessorioMaquinaAssistenciaList
                    }
                );
            }

            return Ok(entradaAssistenciaTecnicaList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EntradaAssistenciaTecnicaViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public EntradaAssistenciaTecnicaViewModel ReadOneAsync(int id)
        {
            var entradaAssistenciaTecnica = _entradaAssistenciaTecnicaService.ReadOneAsync(id);

            try
            {
                var acessorios = entradaAssistenciaTecnica.EntradaAssistenciaAcessorios.Select(x => x.AcessorioId).ToList();

                var entradaDocumentoList = new List<EntradaAssistenciaDocumentoViewModel>();
                foreach (var item in entradaAssistenciaTecnica.EntradaAssistenciaDocumentos)
                {
                    entradaDocumentoList.Add(new EntradaAssistenciaDocumentoViewModel()
                    {
                        Id = item.Id,
                        EntradaAssistenciaTecnicaId = item.EntradaAssistenciaTecnicaId,
                        File = item.File,
                        FileName = item.FileName
                    });
                }

                var entradaAssistenciaTecnicaViewModel = new EntradaAssistenciaTecnicaViewModel()
                {
                    Id = entradaAssistenciaTecnica.Id,
                    PessoaFisica = entradaAssistenciaTecnica.PessoaFisicaId,
                    PessoaJuridica = entradaAssistenciaTecnica.PessoaJuridicaId,
                    ClienteAssociado = entradaAssistenciaTecnica.ClienteAssociadoId,
                    //Nome = entradaAssistenciaTecnica.PessoaFisica?.Nome == null ? entradaAssistenciaTecnica.PessoaJuridica?.RazaoSocial : entradaAssistenciaTecnica.PessoaFisica?.Nome,
                    TipoPessoa = entradaAssistenciaTecnica.PessoaFisica?.Nome == null ? "Juridica" : "Fisica",
                    MaquinaDesc = entradaAssistenciaTecnica.Maquina?.Descricao,
                    FuncionarioDesc = entradaAssistenciaTecnica.Funcionario?.Nome,
                    Funcionario = entradaAssistenciaTecnica.FuncionarioId,
                    NumeroProtocoloTroca = entradaAssistenciaTecnica.NumeroProtocoloTroca,
                    NS = entradaAssistenciaTecnica.NS,
                    CodigoRastreio = entradaAssistenciaTecnica.CodigoRastreio,
                    NumeroRemessa = entradaAssistenciaTecnica.NumeroRemessa,
                    EntreguePor = entradaAssistenciaTecnica.EntreguePorId,
                    DataEntrada = entradaAssistenciaTecnica.DataEntrada,
                    NumeroNF = entradaAssistenciaTecnica.NumeroNF,
                    TrocaJaEfetuada = entradaAssistenciaTecnica.TrocaJaEfetuada,
                    NumeroComprovanteCompra = entradaAssistenciaTecnica.NumeroComprovanteCompra,
                    ComprovanteCompra = entradaAssistenciaTecnica.ComprovanteCompraId,
                    Maquina = entradaAssistenciaTecnica.MaquinaId,
                    NumeroSerie = entradaAssistenciaTecnica.NumeroSerie,                    
                    AcessorioList = acessorios,
                    Descricao = entradaAssistenciaTecnica?.EntradaAssistenciaDescricoes?.FirstOrDefault()?.Descricao,
                    EntradaAssistenciaDocumentoList = entradaDocumentoList,
                    EntradaAssistenciaStatusId = entradaAssistenciaTecnica.EntradaAssistenciaStatusId,
                    Revenda = entradaAssistenciaTecnica.Revenda

                };

                return entradaAssistenciaTecnicaViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(EntradaAssistenciaTecnica), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]EntradaAssistenciaTecnicaViewModel entradaAssistenciaTecnicaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(entradaAssistenciaTecnicaVm.NumeroSerie))
            {
                var numeroSerieExists = _numeroSerieService.NumeroSerieExists(entradaAssistenciaTecnicaVm.NumeroSerie, entradaAssistenciaTecnicaVm.NumeroProtocoloTroca);
                if (numeroSerieExists)
                {
                    ModelState.AddModelError("numeroSerie", "Este número de série já existe");
                    return BadRequest(ModelState);
                }
            }

            var nsExists = _nsService.NSExists(entradaAssistenciaTecnicaVm.NS, entradaAssistenciaTecnicaVm.NS);
            if (nsExists)
            {
                ModelState.AddModelError("NS", "NS já existe");
                return BadRequest(ModelState);
            }

            EntradaAssistenciaTecnica entradaAssistenciaTecnica = new EntradaAssistenciaTecnica();
            entradaAssistenciaTecnica.PessoaFisicaId = entradaAssistenciaTecnicaVm.PessoaFisica;
            entradaAssistenciaTecnica.PessoaJuridicaId = entradaAssistenciaTecnicaVm.PessoaJuridica;
            entradaAssistenciaTecnica.ClienteAssociadoId = entradaAssistenciaTecnicaVm.ClienteAssociado;
            entradaAssistenciaTecnica.FuncionarioId = entradaAssistenciaTecnicaVm.Funcionario;
            entradaAssistenciaTecnica.NumeroProtocoloTroca = entradaAssistenciaTecnicaVm.NumeroProtocoloTroca;
            entradaAssistenciaTecnica.NS = entradaAssistenciaTecnicaVm.NS;
            entradaAssistenciaTecnica.CodigoRastreio = entradaAssistenciaTecnicaVm.CodigoRastreio;
            entradaAssistenciaTecnica.NumeroRemessa = entradaAssistenciaTecnicaVm.NumeroRemessa;
            entradaAssistenciaTecnica.NumeroNF = entradaAssistenciaTecnicaVm.NumeroNF;
            entradaAssistenciaTecnica.TrocaJaEfetuada = entradaAssistenciaTecnicaVm.TrocaJaEfetuada;
            entradaAssistenciaTecnica.EntreguePorId = entradaAssistenciaTecnicaVm.EntreguePor;
            entradaAssistenciaTecnica.DataEntrada = DateTime.Now;
            entradaAssistenciaTecnica.ComprovanteCompraId = entradaAssistenciaTecnicaVm.ComprovanteCompra;
            entradaAssistenciaTecnica.NumeroComprovanteCompra = entradaAssistenciaTecnicaVm.NumeroComprovanteCompra;
            entradaAssistenciaTecnica.MaquinaId = entradaAssistenciaTecnicaVm.Maquina;
            entradaAssistenciaTecnica.NumeroSerie = entradaAssistenciaTecnicaVm.NumeroSerie;
            entradaAssistenciaTecnica.Revenda = entradaAssistenciaTecnicaVm.Revenda;
            entradaAssistenciaTecnica.EntradaAssistenciaStatusId = (int)EntradaAssistenciaStatusEnum.Entrada;

            var createEntradaAssistenciaTecnica = await _entradaAssistenciaTecnicaService.CreateAsync(entradaAssistenciaTecnica);

            if (!string.IsNullOrEmpty(entradaAssistenciaTecnicaVm.Descricao))
            {
                await _entradaAssistenciaTecnicaService.CreateEntradaAssistenciaDescricaoAsync(createEntradaAssistenciaTecnica.Id, entradaAssistenciaTecnicaVm.Descricao, (int)EntradaAssistenciaStatusEnum.Entrada);
            }

            if (entradaAssistenciaTecnicaVm.AcessorioList.Count > 0)
            {
                await _entradaAssistenciaTecnicaService.CreateEntradaAssistenciaAcessorioAsync(createEntradaAssistenciaTecnica.Id, entradaAssistenciaTecnicaVm.AcessorioList);
            }

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createEntradaAssistenciaTecnica.Id.ToString() },
                createEntradaAssistenciaTecnica
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EntradaAssistenciaTecnica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]EntradaAssistenciaTecnicaViewModel entradaAssistenciaTecnicaVm)
        {
            if (entradaAssistenciaTecnicaVm == null || id != entradaAssistenciaTecnicaVm.Id)
                return BadRequest();

            var EntradaAssistenciaTecnicaExists = _entradaAssistenciaTecnicaService.IsEntradaAssistenciaTecnicaExistsAsync(Convert.ToInt32(entradaAssistenciaTecnicaVm.Id));
            if (!EntradaAssistenciaTecnicaExists)
                return NotFound();

            EntradaAssistenciaTecnica entradaAssistenciaTecnica = new EntradaAssistenciaTecnica();
            entradaAssistenciaTecnica.Id = (int)entradaAssistenciaTecnicaVm.Id;
            entradaAssistenciaTecnica.PessoaFisicaId = entradaAssistenciaTecnicaVm.PessoaFisica;
            entradaAssistenciaTecnica.PessoaJuridicaId = entradaAssistenciaTecnicaVm.PessoaJuridica;
            entradaAssistenciaTecnica.ClienteAssociadoId = entradaAssistenciaTecnicaVm.ClienteAssociado;
            entradaAssistenciaTecnica.FuncionarioId = entradaAssistenciaTecnicaVm.Funcionario;
            entradaAssistenciaTecnica.NumeroProtocoloTroca = entradaAssistenciaTecnicaVm.NumeroProtocoloTroca;
            entradaAssistenciaTecnica.NS = entradaAssistenciaTecnicaVm.NS;
            entradaAssistenciaTecnica.CodigoRastreio = entradaAssistenciaTecnicaVm.CodigoRastreio;
            entradaAssistenciaTecnica.NumeroRemessa = entradaAssistenciaTecnicaVm.NumeroRemessa;
            entradaAssistenciaTecnica.NumeroNF = entradaAssistenciaTecnicaVm.NumeroNF;
            entradaAssistenciaTecnica.TrocaJaEfetuada = entradaAssistenciaTecnicaVm.TrocaJaEfetuada;
            entradaAssistenciaTecnica.EntreguePorId = entradaAssistenciaTecnicaVm.EntreguePor;
            entradaAssistenciaTecnica.ComprovanteCompraId = entradaAssistenciaTecnicaVm.ComprovanteCompra;
            entradaAssistenciaTecnica.NumeroComprovanteCompra = entradaAssistenciaTecnicaVm.NumeroComprovanteCompra;
            entradaAssistenciaTecnica.MaquinaId = entradaAssistenciaTecnicaVm.Maquina;
            entradaAssistenciaTecnica.NumeroSerie = entradaAssistenciaTecnicaVm.NumeroSerie;
            entradaAssistenciaTecnica.Revenda = entradaAssistenciaTecnicaVm.Revenda;
            entradaAssistenciaTecnica.EntradaAssistenciaStatusId = (int)EntradaAssistenciaStatusEnum.Entrada;

            await _entradaAssistenciaTecnicaService.UpdateAsync(entradaAssistenciaTecnica);

            await _entradaAssistenciaTecnicaService.DeleteEntradaAssistenciaDescricaoAsync((int)entradaAssistenciaTecnicaVm.Id);

            if (!string.IsNullOrEmpty(entradaAssistenciaTecnicaVm.Descricao))
            {
                await _entradaAssistenciaTecnicaService.CreateEntradaAssistenciaDescricaoAsync((int)entradaAssistenciaTecnicaVm.Id, entradaAssistenciaTecnicaVm.Descricao, (int)EntradaAssistenciaStatusEnum.Entrada);
            }

            await _entradaAssistenciaTecnicaService.SaveDocumentsToDatabase((int)entradaAssistenciaTecnicaVm.Id);

            if (entradaAssistenciaTecnicaVm.AcessorioList.Count > 0)
            {
                await _entradaAssistenciaTecnicaService.CreateEntradaAssistenciaAcessorioAsync((int)entradaAssistenciaTecnicaVm.Id, entradaAssistenciaTecnicaVm.AcessorioList);
            }


            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EntradaAssistenciaTecnica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entradaAssistenciaTecnica = _entradaAssistenciaTecnicaService.ReadOneAsync(id);
            if (entradaAssistenciaTecnica == null)
                return NotFound();

            _entradaAssistenciaTecnicaService.Delete(entradaAssistenciaTecnica);

            return NoContent();
        }
    }
}