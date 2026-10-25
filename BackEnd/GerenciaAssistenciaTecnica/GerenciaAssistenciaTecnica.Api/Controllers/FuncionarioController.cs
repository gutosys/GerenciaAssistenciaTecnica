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
    public class FuncionarioController : BaseApiController
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FuncionarioViewModel>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allFuncionario = await _funcionarioService.ReadAllAsync();

            var funcionarioList = new List<FuncionarioViewModel>();
            foreach (var funcionario in allFuncionario)
            {
                funcionarioList.Add(
                    new FuncionarioViewModel
                    {
                        Id = funcionario.Id,
                        Nome = funcionario.Nome,
                        Sobrenome = funcionario.Sobrenome,
                        Cpf = funcionario.Cpf,
                        Rg = funcionario.Rg,
                        Email = funcionario.Email,
                        Telefone = funcionario.Telefone,
                        Celular = funcionario.Celular
                    }
                );
            }


            return Ok(funcionarioList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Funcionario> ReadOneAsync(int id)
        {

            var funcionario = await _funcionarioService.ReadOneAsync(id);
            return funcionario;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]FuncionarioViewModel funcionarioVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = funcionarioVm.Nome;
            funcionario.Sobrenome = funcionarioVm.Sobrenome;
            funcionario.Cpf = funcionarioVm.Cpf;
            funcionario.Rg = funcionarioVm.Rg;
            funcionario.Email = funcionarioVm?.Email;
            funcionario.Telefone = funcionarioVm?.Telefone;
            funcionario.Celular = funcionarioVm?.Celular;            

            var createFuncionario = await _funcionarioService.CreateAsync(funcionario);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createFuncionario.Id.ToString() },
                createFuncionario
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PessoaFisica), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]FuncionarioViewModel funcionarioVm)
        {
            if (funcionarioVm == null || id != funcionarioVm.Id)
                return BadRequest();

            var funcionarioExists = _funcionarioService.IsFuncionarioExistsAsync(Convert.ToInt32(funcionarioVm.Id));
            if (!funcionarioExists)
                return NotFound();

            Funcionario funcionario = new Funcionario();
            funcionario.Id = Convert.ToInt32(funcionarioVm.Id);
            funcionario.Nome = funcionarioVm.Nome;
            funcionario.Sobrenome = funcionarioVm.Sobrenome;
            funcionario.Cpf = funcionarioVm.Cpf;
            funcionario.Rg = funcionarioVm.Rg;
            funcionario.Email = funcionarioVm?.Email;
            funcionario.Telefone = funcionarioVm?.Telefone;
            funcionario.Celular = funcionarioVm?.Celular;           

            await _funcionarioService.UpdateAsync(funcionario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Funcionario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var funcionario = await _funcionarioService.ReadOneAsync(id);
            if (funcionario == null)
                return NotFound();

            try
            {
                await _funcionarioService.DeleteAsync(funcionario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Não foi possível excluir este registro");
            }
            

            return NoContent();
        }
    }
}