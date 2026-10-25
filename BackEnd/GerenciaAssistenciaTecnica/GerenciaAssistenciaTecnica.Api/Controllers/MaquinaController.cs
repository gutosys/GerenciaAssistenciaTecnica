using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Api.ViewModels;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class MaquinaController : BaseApiController
    {
        private readonly IMaquinaService _maquinaService;

        public MaquinaController(IMaquinaService maquinaService)
        {
            _maquinaService = maquinaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Maquina>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allMaquina = await _maquinaService.ReadAllAsync();
            return Ok(allMaquina);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Maquina), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Maquina> ReadOneAsync(int id)
        {

            var tipoEmpresa = await _maquinaService.ReadOneAsync(id);
            return tipoEmpresa;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MaquinaViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]MaquinaViewModel maquinaVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maquina = new Maquina();
            maquina.Descricao = maquinaVm.Descricao;
            maquina.Modelo = maquinaVm.Modelo;

            var createMaquina = await _maquinaService.CreateAsync(maquina);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createMaquina.Id.ToString() },
                createMaquina
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Maquina), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Maquina maquina)
        {
            if (maquina == null || id != maquina.Id)
                return BadRequest();

            var tipoEmpresaExists = _maquinaService.IsMaquinaExistsAsync(maquina.Id);
            if (!tipoEmpresaExists)
                return NotFound();

            await _maquinaService.UpdateAsync(maquina);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Maquina), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var maquina = await _maquinaService.ReadOneAsync(id);
            if (maquina == null)
                return NotFound();

            await _maquinaService.DeleteAsync(maquina);

            return NoContent();
        }





















    }
}