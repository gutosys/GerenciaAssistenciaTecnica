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
    public class EstoqueController : BaseApiController
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService ?? throw new ArgumentNullException(nameof(estoqueService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EstoqueViewModel>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allEstoque = await _estoqueService.ReadAllAsync();

            var estoqueList = new List<EstoqueViewModel>();
            foreach (var estoque in allEstoque)
            {
                estoqueList.Add(
                    new EstoqueViewModel
                    {
                        Id = estoque.Id,
                        ComponenteId = estoque.ComponenteId,
                        ComponenteDes = estoque.Componente.Nome,
                        Quantidade = estoque.Quantidade,
                        QuantidadeMinima = estoque.QuantidadeMinima
                    }
                );
            }

            return Ok(estoqueList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Estoque), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Estoque> ReadOneAsync(int id)
        {

            var estoque = await _estoqueService.ReadOneAsync(id);
            return estoque;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Estoque), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]EstoqueViewModel estoqueVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Estoque estoque = new Estoque();
            estoque.ComponenteId = estoqueVm.ComponenteId;
            estoque.Quantidade = estoqueVm.Quantidade;
            estoque.QuantidadeMinima = estoqueVm.QuantidadeMinima;

            var createEstoque = await _estoqueService.CreateAsync(estoque);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createEstoque.Id.ToString() },
                createEstoque
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Estoque), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]EstoqueViewModel estoqueVm)
        {
            if (estoqueVm == null || id != estoqueVm.Id)
                return BadRequest();

            var estoqueExists = _estoqueService.IsEstoqueExistsAsync(Convert.ToInt32(estoqueVm.Id));
            if (!estoqueExists)
                return NotFound();

            Estoque estoque = new Estoque();
            estoque.Id = (int)estoqueVm.Id;
            estoque.ComponenteId = estoqueVm.ComponenteId;
            estoque.Quantidade = estoqueVm.Quantidade;
            estoque.QuantidadeMinima = estoqueVm.QuantidadeMinima;

            await _estoqueService.UpdateAsync(estoque);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Estoque), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var estoque = await _estoqueService.ReadOneAsync(id);
            if (estoque == null)
                return NotFound();

            _estoqueService.Delete(estoque);

            return NoContent();
        }
    }
}