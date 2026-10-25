using GerenciaAssistenciaTecnica.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePessoaFisicaController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientePessoaFisicaController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }
    }
}