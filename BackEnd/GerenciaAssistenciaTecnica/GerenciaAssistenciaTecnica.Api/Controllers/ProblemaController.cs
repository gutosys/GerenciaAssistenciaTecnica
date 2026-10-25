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
    public class ProblemaController : BaseApiController
    {
        private readonly IProblemaService _problemaService;

        public ProblemaController(IProblemaService problemaService)
        {
            _problemaService = problemaService ?? throw new ArgumentNullException(nameof(problemaService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Problema>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allProblema = await _problemaService.ReadAllAsync();
            return Ok(allProblema);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Problema), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Problema> ReadOneAsync(int id)
        {

            var problema = await _problemaService.ReadOneAsync(id);
            return problema;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProblemaViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]ProblemaViewModel problema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Problema tp = new Problema();
            tp.Descricao = problema.Descricao;

            var createProblema = await _problemaService.CreateAsync(tp);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createProblema.Id.ToString() },
                createProblema
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Problema), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Problema problema)
        {
            if (problema == null || id != problema.Id)
                return BadRequest();

            var problemaExists = _problemaService.IsProblemaExistsAsync(problema.Id);
            if (!problemaExists)
                return NotFound();

            await _problemaService.UpdateAsync(problema);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Problema), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var problema = await _problemaService.ReadOneAsync(id);
            if (problema == null)
                return NotFound();

            await _problemaService.DeleteAsync(problema);

            return NoContent();
        }
    }
}