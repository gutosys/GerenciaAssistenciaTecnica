using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class EtiquetaController : BaseApiController
    {
        private readonly IEtiquetaService _etiquetaService;

        public EtiquetaController(IEtiquetaService etiquetaService)
        {
            _etiquetaService = etiquetaService ?? throw new ArgumentNullException(nameof(etiquetaService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Etiqueta>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allEtiqueta = await _etiquetaService.ReadAllAsync();

            List<EtiquetaViewModel> list = new List<EtiquetaViewModel>();
            foreach (var etiqueta in allEtiqueta)
            {
                list.Add(new EtiquetaViewModel
                {
                    Id = etiqueta.Id,
                    CorId = etiqueta.CorId,
                    Descricao = etiqueta.Descricao,
                    ColorHex = etiqueta.Cor.ColorHex,
                    CorDes = etiqueta.Cor.Descricao
                });
            }

            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Etiqueta), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<EtiquetaViewModel> ReadOneAsync(int id)
        {

            var etiqueta = await _etiquetaService.ReadOneAsync(id);

            var etiq = new EtiquetaViewModel
            {
                Id = etiqueta.Id,
                CorId = etiqueta.CorId,
                Descricao = etiqueta.Descricao,
                ColorHex = etiqueta.Cor.ColorHex,
                CorDes = etiqueta.Cor.Descricao
            };

            return etiq;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Etiqueta), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]EtiquetaViewModel etiqueta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eti = new Etiqueta
            {
                Descricao = etiqueta.Descricao,
                CorId = etiqueta.CorId
            };

            var createEtiqueta = await _etiquetaService.CreateAsync(eti);

            return CreatedAtAction(
                nameof(ReadOneAsync),
                 new { id = createEtiqueta.Id.ToString() },
                createEtiqueta
                );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Etiqueta), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]Etiqueta etiqueta)
        {
            if (etiqueta == null || id != etiqueta.Id)
                return BadRequest();

            var etiquetaExists = _etiquetaService.IsEtiquetaExistsAsync(etiqueta.Id);
            if (!etiquetaExists)
                return NotFound();

            await _etiquetaService.UpdateAsync(etiqueta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Etiqueta), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var etiqueta = await _etiquetaService.ReadOneAsync(id);
            if (etiqueta == null)
                return NotFound();

            await _etiquetaService.DeleteAsync(etiqueta);

            return NoContent();
        }
    }
}