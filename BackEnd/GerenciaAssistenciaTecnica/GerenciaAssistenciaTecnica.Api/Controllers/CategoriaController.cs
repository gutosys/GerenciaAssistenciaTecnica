using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Api.ViewModels;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class CategoriaController : BaseApiController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService ?? throw new ArgumentNullException(nameof(categoriaService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Categoria>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allTipoEmpresa = await _categoriaService.ReadAllAsync();
            return Ok(allTipoEmpresa);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Categoria> ReadOneAsync(int id)
        {

            var categoria = await _categoriaService.ReadOneAsync(id);
            return categoria;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TipoEmpresaViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categoria tp = new Categoria();
            tp.Descricao = categoria.Descricao;

            var createTipoEmpresa = await _categoriaService.CreateAsync(tp);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createTipoEmpresa.Id.ToString() },
                createTipoEmpresa
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Categoria categoria)
        {
            if (categoria == null || id != categoria.Id)
                return BadRequest();

            var categoriaExists = _categoriaService.IsCategoriaExistsAsync(categoria.Id);
            if (!categoriaExists)
                return NotFound();

            await _categoriaService.UpdateAsync(categoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var categoria = await _categoriaService.ReadOneAsync(id);
            if (categoria == null)
                return NotFound();

            await _categoriaService.DeleteAsync(categoria);

            return NoContent();
        }
    }
}