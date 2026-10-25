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
    public class EntreguePorController : BaseApiController 
    {
        private readonly IEntreguePorService _entreguePorService;
        public EntreguePorController(IEntreguePorService entreguePorService)
        {
            this._entreguePorService = entreguePorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EntreguePor>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allTipoEmpresa = await _entreguePorService.ReadAllAsync();
            return Ok(allTipoEmpresa);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EntreguePor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<EntreguePor> ReadOneAsync(int id)
        {

            var entreguePor = await _entreguePorService.ReadOneAsync(id);
            return entreguePor;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EntreguePorViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]EntreguePorViewModel entreguePor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EntreguePor tp = new EntreguePor();
            tp.Descricao = entreguePor.Descricao;

            var createentreguePor = await _entreguePorService.CreateAsync(tp);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createentreguePor.Id.ToString() },
                createentreguePor
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EntreguePor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]EntreguePor entreguePor)
        {
            if (entreguePor == null || id != entreguePor.Id)
                return BadRequest();

            var entreguePorExists = _entreguePorService.IsEntreguePorExistsAsync(entreguePor.Id);
            if (!entreguePorExists)
                return NotFound();

            await _entreguePorService.UpdateAsync(entreguePor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EntreguePor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entreguePor = await _entreguePorService.ReadOneAsync(id);
            if (entreguePor == null)
                return NotFound();

            await _entreguePorService.DeleteAsync(entreguePor);

            return NoContent();
        }
    }
}