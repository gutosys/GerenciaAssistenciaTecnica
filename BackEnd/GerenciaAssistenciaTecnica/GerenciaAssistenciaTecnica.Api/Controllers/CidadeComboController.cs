using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeComboController : ControllerBase
    {        
        private readonly ICidadeComboService _cidadeComboService;

        public CidadeComboController(ICidadeComboService cidadeComboService)
        {
            _cidadeComboService = cidadeComboService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Cidade>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Cidade>> ReadOneAsync(int id)
        {
            var cidadeCombo = _cidadeComboService.ReadListByEstado(id);
            return cidadeCombo;
        }
    }
}