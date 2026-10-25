using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Api.ViewModels;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class PessoaJuridicaController : BaseApiController
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaController(IPessoaJuridicaService pessoaJuridicaService)
        {
            _pessoaJuridicaService = pessoaJuridicaService ?? throw new ArgumentNullException(nameof(pessoaJuridicaService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PessoaJuridica>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allPessoaJuridica = await _pessoaJuridicaService.ReadAllAsync();

            var pessoaJuridicaList = new List<PessoaJuridicaCreateViewModel>();
            foreach (var pessoa in allPessoaJuridica)
            {
                pessoaJuridicaList.Add(
                    new PessoaJuridicaCreateViewModel
                    {
                        Id = pessoa.Id,                        
                        RegimeTributarioId = pessoa.RegimeTributarioId,
                        Email = pessoa.Cliente.Email,
                        Telefone = pessoa.Cliente.Telefone,
                        Celular = pessoa.Cliente.Celular,                        
                        Rua = pessoa.Cliente.Endereco.Rua,
                        Bairro = pessoa.Cliente.Endereco.Bairro,
                        Numero = pessoa.Cliente.Endereco.Numero,
                        Cep = pessoa.Cliente.Endereco.Cep,
                        CidadeId = (int)pessoa.Cliente.Endereco.CidadeId,
                        EstadoId = (int)pessoa.Cliente.Endereco.EstadoId,
                        ClienteId = (int)pessoa.ClienteId,
                        EnderecoId = (int)pessoa.Cliente.EnderecoId,
                        TipoPessoa = TipoPessoaEnum.PessoaJuridica,
                        RazaoSocial = pessoa.RazaoSocial,
                        NomeFantasia = pessoa.NomeFantasia,
                        Cnpj = pessoa.Cnpj,
                        IE = pessoa.IE
                    }
                );
            }

            return Ok(pessoaJuridicaList);


        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaJuridica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PessoaJuridica> ReadOneAsync(int id)
        {

            var pessoaJuridica = await _pessoaJuridicaService.ReadOneAsync(id);
            return pessoaJuridica;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PessoaJuridica), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]PessoaJuridicaCreateViewModel pessoaJuridicaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(pessoaJuridicaVm.Cnpj))
            {
                var pessoaJuridicaExists = _pessoaJuridicaService.IsCnpjExistsAsync(pessoaJuridicaVm.Cnpj);
                if (pessoaJuridicaExists)
                {
                    ModelState.AddModelError("pessoaJuridica", "Este Cnpj já existe");
                    return BadRequest(ModelState);
                }
            }

            Cliente cli = new Cliente();
            cli.Email = pessoaJuridicaVm.Email;
            cli.Telefone = pessoaJuridicaVm.Telefone;
            cli.Celular = pessoaJuridicaVm.Celular;
            cli.TipoPessoa = TipoPessoaEnum.PessoaJuridica;

            PessoaJuridica pj = new PessoaJuridica();
            pj.RazaoSocial = pessoaJuridicaVm.RazaoSocial;
            pj.NomeFantasia = pessoaJuridicaVm.NomeFantasia;
            pj.Cnpj = pessoaJuridicaVm.Cnpj;
            pj.IE = pessoaJuridicaVm.IE;            
            pj.RegimeTributarioId = pessoaJuridicaVm.RegimeTributarioId;

            pj.Cliente = cli;

            Endereco end = new Endereco();
            end.Rua = pessoaJuridicaVm.Rua;
            end.Bairro = pessoaJuridicaVm.Bairro;
            end.Numero = pessoaJuridicaVm.Numero;
            end.Cep = pessoaJuridicaVm.Cep;
            end.CidadeId = pessoaJuridicaVm.CidadeId;
            end.EstadoId = pessoaJuridicaVm.EstadoId;

            cli.Endereco = end;

            var createPessoaJuridica = await _pessoaJuridicaService.CreateAsync(pj, end, cli);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createPessoaJuridica.Id.ToString() },
                createPessoaJuridica
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PessoaJuridica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]PessoaJuridicaCreateViewModel pessoaJuridicaVm)
        {
            if (pessoaJuridicaVm == null || id != pessoaJuridicaVm.Id)
                return BadRequest();

            var pessoaJuridicaExists = _pessoaJuridicaService.IsPessoaJuridicaExistsAsync((int)pessoaJuridicaVm.Id);
            if (!pessoaJuridicaExists)
                return NotFound();

            Cliente cli = new Cliente();
            cli.Id = (int)pessoaJuridicaVm.ClienteId;
            cli.Email = pessoaJuridicaVm.Email;
            cli.Telefone = pessoaJuridicaVm.Telefone;
            cli.Celular = pessoaJuridicaVm.Celular;
            cli.TipoPessoa = TipoPessoaEnum.PessoaJuridica;

            PessoaJuridica pj = new PessoaJuridica();
            pj.Id = (int)pessoaJuridicaVm.Id;
            pj.RazaoSocial = pessoaJuridicaVm.RazaoSocial;
            pj.NomeFantasia = pessoaJuridicaVm.NomeFantasia;
            pj.Cnpj = pessoaJuridicaVm.Cnpj;
            pj.IE = pessoaJuridicaVm.IE;            
            pj.RegimeTributarioId = pessoaJuridicaVm.RegimeTributarioId;

            pj.Cliente = cli;

            Endereco end = new Endereco();
            end.Id = (int)pessoaJuridicaVm.EnderecoId;
            end.Rua = pessoaJuridicaVm.Rua;
            end.Bairro = pessoaJuridicaVm.Bairro;
            end.Numero = pessoaJuridicaVm.Numero;
            end.Cep = pessoaJuridicaVm.Cep;
            end.CidadeId = pessoaJuridicaVm.CidadeId;
            end.EstadoId = pessoaJuridicaVm.EstadoId;

            cli.Endereco = end;

            await _pessoaJuridicaService.UpdateAsync(pj, end, cli);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PessoaJuridica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pessoaJuridica = await _pessoaJuridicaService.ReadOneAsync(id);
            if (pessoaJuridica == null)
                return NotFound();

            _pessoaJuridicaService.Delete(pessoaJuridica);

            return NoContent();
        }
    }
}