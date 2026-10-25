using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePessoaJuridicaController : ControllerBase
    {

        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ClientePessoaJuridica>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ReadAllAsync()
        {
            //var allClientePessoaJuridica = await _ninjaService.ReadAllAsync();
            //return Ok(allNinja);

            throw new NotImplementedException();
        }
    }
}