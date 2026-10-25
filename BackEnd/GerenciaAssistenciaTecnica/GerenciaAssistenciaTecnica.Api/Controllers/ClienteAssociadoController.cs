using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Api.ViewModels;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{   
    public class ClienteAssociadoController : BaseApiController
    {
        private readonly IClienteAssociadoService _clienteAssociadoService;

        public ClienteAssociadoController(IClienteAssociadoService clienteAssociadoService)
        {
            _clienteAssociadoService = clienteAssociadoService ?? throw new ArgumentNullException(nameof(clienteAssociadoService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteAssociado>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allClienteAssociado = await _clienteAssociadoService.ReadAllAsync();

            var clienteAssociadoList = new List<ClienteAssociadoViewModel>();
            foreach (var clienteAssociado in allClienteAssociado)
            {
                clienteAssociadoList.Add(
                    new ClienteAssociadoViewModel
                    {
                        Id = clienteAssociado.Id,
                        Nome = clienteAssociado.Nome,
                        Telefone = clienteAssociado.Telefone,
                        PessoaJuridicaId = clienteAssociado.PessoaJuridicaId,
                        PessoaJuridicaDes = clienteAssociado.PessoaJuridica.RazaoSocial + clienteAssociado.PessoaJuridica.Cnpj
                    }
                );
            }


            return Ok(clienteAssociadoList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteAssociado), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ClienteAssociado> ReadOneAsync(int id)
        {

            var clienteAssociado = await _clienteAssociadoService.ReadOneAsync(id);
            return clienteAssociado;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteAssociado), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]ClienteAssociadoViewModel clienteAssociadoVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClienteAssociado clienteAssociado = new ClienteAssociado();
            clienteAssociado.Nome = clienteAssociadoVm.Nome;
            clienteAssociado.Telefone = clienteAssociadoVm.Telefone;

            clienteAssociado.PessoaJuridicaId = clienteAssociadoVm.PessoaJuridicaId;            

            var createClienteAssociado = await _clienteAssociadoService.CreateAsync(clienteAssociado);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createClienteAssociado.Id.ToString() },
                       createClienteAssociado
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClienteAssociado), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]ClienteAssociadoViewModel clienteAssociadoVm)
        {
            if (clienteAssociadoVm == null || id != clienteAssociadoVm.Id)
                return BadRequest();

            var clienteAssociadoExists = _clienteAssociadoService.IsClienteAssociadoExistsAsync((int)clienteAssociadoVm.Id);
            if (!clienteAssociadoExists)
                return NotFound();

            ClienteAssociado clienteAssociado = new ClienteAssociado();
            clienteAssociado.Id = Convert.ToInt32(clienteAssociadoVm.Id);
            clienteAssociado.Nome = clienteAssociadoVm.Nome;
            clienteAssociado.Telefone = clienteAssociadoVm.Telefone;
            clienteAssociado.PessoaJuridicaId = clienteAssociadoVm.PessoaJuridicaId;

            await _clienteAssociadoService.UpdateAsync(clienteAssociado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteAssociado), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var clienteAssociado = await _clienteAssociadoService.ReadOneAsync(id);
            if (clienteAssociado == null)
                return NotFound();

            await _clienteAssociadoService.DeleteAsync(clienteAssociado);

            return NoContent();
        }
    }
}