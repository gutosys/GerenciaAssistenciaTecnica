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
    public class ComponenteController : BaseApiController
    {
        private readonly IComponenteService _componenteService;

        public ComponenteController(IComponenteService componenteService)
        {
            _componenteService = componenteService ?? throw new ArgumentNullException(nameof(componenteService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ComponenteViewModel>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allComponente = await _componenteService.ReadAllAsync();

            var componenteList = new List<ComponenteViewModel>();
            foreach (var componente in allComponente)
            {
                componenteList.Add(
                    new ComponenteViewModel
                    {
                        Id = componente.Id,
                        Nome = componente.Nome,
                        Descricao = componente.Descricao,
                        PrecoCompra = componente.PrecoCompra,
                        PrecoVenda = componente.PrecoVenda,
                        PrecoVendaAutorizada = componente.PrecoVendaAutorizada
                    }
                );
            }

            return Ok(componenteList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Componente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Componente> ReadOneAsync(int id)
        {

            var componente = await _componenteService.ReadOneAsync(id);
            return componente;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Componente), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]ComponenteViewModel componenteVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Componente componente = new Componente();
            componente.Nome = componenteVm.Nome;
            componente.Descricao = componenteVm.Descricao;
            componente.PrecoCompra = componenteVm.PrecoCompra;
            componente.PrecoVenda = componenteVm.PrecoVenda;
            componente.PrecoVendaAutorizada = componenteVm.PrecoVendaAutorizada;

            var createComponente = await _componenteService.CreateAsync(componente);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createComponente.Id.ToString() },
                createComponente
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Componente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]ComponenteViewModel componenteVm)
        {
            if (componenteVm == null || id != componenteVm.Id)
                return BadRequest();

            var componenteExists = _componenteService.IsComponenteExistsAsync(Convert.ToInt32(componenteVm.Id));
            if (!componenteExists)
                return NotFound();

            Componente componente = new Componente();
            componente.Id = Convert.ToInt32(componenteVm.Id);
            componente.Nome = componenteVm.Nome;
            componente.Descricao = componenteVm.Descricao;
            componente.PrecoCompra = componenteVm.PrecoCompra;
            componente.PrecoVenda = componenteVm.PrecoVenda;
            componente.PrecoVendaAutorizada = componenteVm.PrecoVendaAutorizada;

            await _componenteService.UpdateAsync(componente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Componente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var componente = await _componenteService.ReadOneAsync(id);
            if (componente == null)
                return NotFound();

            _componenteService.Delete(componente);

            return NoContent();
        }
    }
}