using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{   
    public class MaquinaClienteController : BaseApiController
    {
        private readonly IMaquinaClienteService _maquinaClienteService;

        public MaquinaClienteController(IMaquinaClienteService maquinaClienteService)
        {
            _maquinaClienteService = maquinaClienteService ?? throw new ArgumentNullException(nameof(maquinaClienteService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MaquinaCliente>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allMaquinaCliente = await _maquinaClienteService.ReadAllAsync();
            return Ok(allMaquinaCliente);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MaquinaCliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<MaquinaCliente> ReadOneAsync(int id)
        {

            var tipoEmpresa = await _maquinaClienteService.ReadOneAsync(id);
            return tipoEmpresa;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MaquinaCliente), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]MaquinaCliente maquinaCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createMaquinaCliente = await _maquinaClienteService.CreateAsync(maquinaCliente);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createMaquinaCliente.Id.ToString() },
                createMaquinaCliente
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MaquinaCliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]MaquinaCliente maquinaCliente)
        {
            if (maquinaCliente == null || id != maquinaCliente.Id)
                return BadRequest();

            var tipoEmpresaExists = _maquinaClienteService.IsMaquinaClienteExistsAsync(maquinaCliente.Id);
            if (!tipoEmpresaExists)
                return NotFound();

            await _maquinaClienteService.UpdateAsync(maquinaCliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MaquinaCliente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var maquinaCliente = await _maquinaClienteService.ReadOneAsync(id);
            if (maquinaCliente == null)
                return NotFound();

            await _maquinaClienteService.DeleteAsync(maquinaCliente);

            return NoContent();
        }


















    }
}