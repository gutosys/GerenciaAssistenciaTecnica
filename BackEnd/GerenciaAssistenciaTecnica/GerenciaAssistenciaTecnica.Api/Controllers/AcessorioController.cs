using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Api.ViewModels;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class AcessorioController : BaseApiController
    {
        private readonly IAcessorioService _acessorioService;

        public AcessorioController(IAcessorioService acessorioService)
        {
            _acessorioService  = acessorioService ?? throw new ArgumentNullException(nameof(acessorioService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Acessorio>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allAcessorio = await _acessorioService.ReadAllAsync();
            return Ok(allAcessorio);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Acessorio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Acessorio> ReadOneAsync(int id)
        {

            var acessorio = await _acessorioService.ReadOneAsync(id);
            return acessorio;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AcessorioViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]AcessorioViewModel acessorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Acessorio tp = new Acessorio();
            tp.Descricao = acessorio.Descricao;

            var createAcessorio = await _acessorioService.CreateAsync(tp);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createAcessorio.Id.ToString() },
                createAcessorio
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Acessorio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Acessorio acessorio)
        {
            if (acessorio == null || id != acessorio.Id)
                return BadRequest();

            var acessorioExists = _acessorioService.IsAcessorioExistsAsync(acessorio.Id);
            if (!acessorioExists)
                return NotFound();

            await _acessorioService.UpdateAsync(acessorio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Acessorio), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var acessorio = await _acessorioService.ReadOneAsync(id);
            if (acessorio == null)
                return NotFound();

            try
            {
                await _acessorioService.DeleteAsync(acessorio);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Não foi possível excluir este registro");
            }

            return NoContent();
        }

    }
}