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
    public class ComprovanteCompraController : BaseApiController
    {
        private readonly IComprovanteCompraService _comprovanteCompraService;
        public ComprovanteCompraController(IComprovanteCompraService comprovanteCompraService)
        {
            this._comprovanteCompraService = comprovanteCompraService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ComprovanteCompra>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allTipoEmpresa = await _comprovanteCompraService.ReadAllAsync();
            return Ok(allTipoEmpresa);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ComprovanteCompra), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ComprovanteCompra> ReadOneAsync(int id)
        {

            var comprovanteCompra = await _comprovanteCompraService.ReadOneAsync(id);
            return comprovanteCompra;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ComprovanteCompraViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]ComprovanteCompraViewModel comprovanteCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ComprovanteCompra tp = new ComprovanteCompra();
            tp.Descricao = comprovanteCompra.Descricao;

            var createcomprovanteCompra = await _comprovanteCompraService.CreateAsync(tp);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createcomprovanteCompra.Id.ToString() },
                createcomprovanteCompra
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ComprovanteCompra), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]ComprovanteCompra comprovanteCompra)
        {
            if (comprovanteCompra == null || id != comprovanteCompra.Id)
                return BadRequest();

            var comprovanteCompraExists = _comprovanteCompraService.IsComprovanteCompraExistsAsync(comprovanteCompra.Id);
            if (!comprovanteCompraExists)
                return NotFound();

            await _comprovanteCompraService.UpdateAsync(comprovanteCompra);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ComprovanteCompra), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var comprovanteCompra = await _comprovanteCompraService.ReadOneAsync(id);
            if (comprovanteCompra == null)
                return NotFound();

            await _comprovanteCompraService.DeleteAsync(comprovanteCompra);

            return NoContent();
        }
    }
}