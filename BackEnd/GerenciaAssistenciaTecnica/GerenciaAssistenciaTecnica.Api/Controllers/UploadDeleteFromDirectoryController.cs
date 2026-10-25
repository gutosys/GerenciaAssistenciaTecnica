using GerenciaAssistenciaTecnica.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class UploadDeleteFromDirectoryController : BaseApiController
    {
        private readonly IEntradaAssistenciaTecnicaService _entradaAssistenciaTecnicaService;

        public UploadDeleteFromDirectoryController(IEntradaAssistenciaTecnicaService entradaAssistenciaTecnicaService)
        {
            this._entradaAssistenciaTecnicaService = entradaAssistenciaTecnicaService;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAsync(int id)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToCheck = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                pathToCheck = pathToCheck + "\\" + "Entrada_Assistencia_Id_" + id;

                if (Directory.Exists(pathToCheck))
                {
                    Directory.Delete(pathToCheck, true);                    
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}