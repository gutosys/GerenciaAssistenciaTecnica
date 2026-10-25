using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class UploadCheckDocumentoController : BaseApiController
    {
        [HttpGet("{id}")]
        public IActionResult CheckDocumento(int id)
        {
            int numeroDeArquivos = 0;
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToCheck = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                pathToCheck = pathToCheck + "\\" + "Entrada_Assistencia_Id_" + id;

                if (Directory.Exists(pathToCheck))
                {
                    numeroDeArquivos = Directory.GetFiles(pathToCheck, "*", SearchOption.AllDirectories).Length;                    
                }                

                return Ok(numeroDeArquivos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}