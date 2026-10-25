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
    public class PessoaFisicaController : BaseApiController
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService ?? throw new ArgumentNullException(nameof(pessoaFisicaService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PessoaFisicaViewModel>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allPessoaFisica = await _pessoaFisicaService.ReadAllAsync();

            var pessoaFisicaList = new List<PessoaFisicaViewModel>();
            foreach (var pessoa in allPessoaFisica)
            {
                pessoaFisicaList.Add(
                    new PessoaFisicaViewModel
                    {
                        Id = pessoa.Id,
                        Nome = pessoa.Nome,
                        Sobrenome = pessoa.Sobrenome,
                        Cpf = pessoa.Cpf,
                        Rg = pessoa.Rg,
                        Email = pessoa.Cliente.Email,
                        Telefone = pessoa.Cliente.Telefone,
                        Celular = pessoa.Cliente.Celular,
                        Rua = pessoa.Cliente.Endereco.Rua,
                        Bairro = pessoa.Cliente.Endereco.Bairro,
                        Numero = pessoa.Cliente.Endereco.Numero,
                        Cep = pessoa.Cliente.Endereco.Cep,
                        CidadeId = pessoa.Cliente.Endereco.CidadeId,
                        EstadoId = pessoa.Cliente.Endereco.EstadoId,
                        ClienteId = pessoa.Cliente.Id,
                        EnderecoId = pessoa.Cliente.Endereco.Id
                    }
                );
            }


            return Ok(pessoaFisicaList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PessoaFisica> ReadOneAsync(int id)
        {

            var pessoaFisica = await _pessoaFisicaService.ReadOneAsync(id);
            return pessoaFisica;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]PessoaFisicaViewModel pessoaFisicaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(pessoaFisicaVm.Cpf))
            {
                var pessoaFisicaExists = _pessoaFisicaService.IsCpfExistsAsync(pessoaFisicaVm.Cpf);
                if (pessoaFisicaExists)
                {
                    ModelState.AddModelError("pessoaFisica", "Este Cpf já existe");
                    return BadRequest(ModelState);
                }
            }

            Cliente cli = new Cliente();
            cli.Email = pessoaFisicaVm?.Email;
            cli.Telefone = pessoaFisicaVm?.Telefone;
            cli.Celular = pessoaFisicaVm?.Celular;
            cli.TipoPessoa = TipoPessoaEnum.PessoaFisica;

            PessoaFisica pf = new PessoaFisica();
            pf.Nome = pessoaFisicaVm.Nome;
            pf.Sobrenome = pessoaFisicaVm.Sobrenome;
            pf.Cpf = pessoaFisicaVm.Cpf;
            pf.Rg = pessoaFisicaVm.Rg;

            pf.Cliente = cli;

            Endereco end = new Endereco();
            end.Rua = pessoaFisicaVm?.Rua;
            end.Bairro = pessoaFisicaVm?.Bairro;
            end.Numero = pessoaFisicaVm?.Numero;
            end.Cep = pessoaFisicaVm?.Cep;
            end.CidadeId = pessoaFisicaVm?.CidadeId;
            end.EstadoId = pessoaFisicaVm?.EstadoId;

            cli.Endereco = end;

            var createPessoaFisica = await _pessoaFisicaService.CreateAsync(pf, end, cli);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createPessoaFisica.Id.ToString() },
                createPessoaFisica
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]PessoaFisicaViewModel pessoaFisicaVm)
        {
            if (pessoaFisicaVm == null || id != pessoaFisicaVm.Id)
                return BadRequest();

            var pessoaFisicaExists = _pessoaFisicaService.IsPessoaFisicaExistsAsync(Convert.ToInt32(pessoaFisicaVm.Id));
            if (!pessoaFisicaExists)
                return NotFound();

            Cliente cli = new Cliente();
            cli.Id = (int)pessoaFisicaVm.ClienteId;
            cli.Email = pessoaFisicaVm.Email;
            cli.Telefone = pessoaFisicaVm.Telefone;
            cli.Celular = pessoaFisicaVm.Celular;
            cli.TipoPessoa = TipoPessoaEnum.PessoaFisica;


            PessoaFisica pf = new PessoaFisica();
            pf.Id = Convert.ToInt32(pessoaFisicaVm.Id);
            pf.Nome = pessoaFisicaVm.Nome;
            pf.Sobrenome = pessoaFisicaVm.Sobrenome;
            pf.Cpf = pessoaFisicaVm.Cpf;
            pf.Rg = pessoaFisicaVm.Rg;

            pf.Cliente = cli;

            Endereco end = new Endereco();
            end.Id = pessoaFisicaVm.EnderecoId;
            end.Rua = pessoaFisicaVm.Rua;
            end.Bairro = pessoaFisicaVm.Bairro;
            end.Numero = pessoaFisicaVm.Numero;
            end.Cep = pessoaFisicaVm.Cep;
            end.CidadeId = pessoaFisicaVm.CidadeId;
            end.EstadoId = pessoaFisicaVm.EstadoId;

            cli.Endereco = end;

            await _pessoaFisicaService.UpdateAsync(pf, end, cli);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pessoaFisica = await _pessoaFisicaService.ReadOneAsync(id);
            if (pessoaFisica == null)
                return NotFound();

            _pessoaFisicaService.Delete(pessoaFisica);

            return NoContent();
        }
    }
}