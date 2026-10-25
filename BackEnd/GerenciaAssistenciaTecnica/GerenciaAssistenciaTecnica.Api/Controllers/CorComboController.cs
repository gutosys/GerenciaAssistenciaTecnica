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
    public class CorComboController : BaseApiController
    {
        private readonly ICorComboService _corComboService;

        public CorComboController(ICorComboService corComboService)
        {
            _corComboService = corComboService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cor>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Cor>> ReadOneAsync()
        {
            var corCombo = _corComboService.ReadList();
            return corCombo;
        }
    }
}