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
    public class RegimeTributarioController : BaseApiController
    {
        private readonly IRegimeTributarioService _regimeTributarioService;

        public RegimeTributarioController(IRegimeTributarioService regimeTributarioService)
        {
            _regimeTributarioService  = regimeTributarioService ?? throw new ArgumentNullException(nameof(regimeTributarioService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RegimeTributario>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allRegimeTributario = await _regimeTributarioService.ReadAllAsync();
            return Ok(allRegimeTributario);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegimeTributario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<RegimeTributario> ReadOneAsync(int id)
        {

            var regimeTributario = await _regimeTributarioService.ReadOneAsync(id);
            return regimeTributario;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegimeTributarioViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]RegimeTributarioViewModel regimeTributarioVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegimeTributario rt = new RegimeTributario();
            rt.Descricao = regimeTributarioVm.Descricao;

            var createRegimeTributario = await _regimeTributarioService.CreateAsync(rt);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createRegimeTributario.Id.ToString() },
                            createRegimeTributario
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RegimeTributario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]RegimeTributario regimeTributario)
        {
            if (regimeTributario == null || id != regimeTributario.Id)
                return BadRequest();

            var regimeTributarioExists = _regimeTributarioService.IsRegimeTributarioExistsAsync(regimeTributario.Id);
            if (!regimeTributarioExists)
                return NotFound();

            await _regimeTributarioService.UpdateAsync(regimeTributario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RegimeTributario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var regimeTributario = await _regimeTributarioService.ReadOneAsync(id);
            if (regimeTributario == null)
                return NotFound();

            await _regimeTributarioService.DeleteAsync(regimeTributario);

            return NoContent();
        }
    }
}