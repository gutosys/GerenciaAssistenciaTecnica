using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{   
    public class CidadeController : BaseApiController
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService ?? throw new ArgumentNullException(nameof(cidadeService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cidade>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allCidade = await _cidadeService.ReadAllAsync();
            return Ok(allCidade);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cidade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Cidade> ReadOneAsync(int id)
        {

            var cidade = await _cidadeService.ReadOneAsync(id);
            return cidade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cidade), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createCidade = await _cidadeService.CreateAsync(cidade);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createCidade.Id.ToString() },
                createCidade
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cidade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Cidade cidade)
        {
            if (cidade == null || id != cidade.Id)
                return BadRequest();

            var cidadeExists = _cidadeService.IsCidadeExistsAsync(cidade.Id);
            if (!cidadeExists)
                return NotFound();

            await _cidadeService.UpdateAsync(cidade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cidade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var cidade = await _cidadeService.ReadOneAsync(id);
            if (cidade == null)
                return NotFound();

            await _cidadeService.DeleteAsync(cidade);

            return NoContent();
        }
    }
}