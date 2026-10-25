using GerenciaAssistenciaTecnica.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Controllers
{
    public class UploadController : BaseApiController
    {
        private readonly IEntradaAssistenciaTecnicaService _entradaAssistenciaTecnicaService;

        public UploadController(IEntradaAssistenciaTecnicaService entradaAssistenciaTecnicaService)
        {
            this._entradaAssistenciaTecnicaService = entradaAssistenciaTecnicaService;
        }


        [HttpPost, DisableRequestSizeLimit]
        //[ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];                
                StringValues id = string.Empty;
                Request.Form.TryGetValue("id", out id);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                pathToSave = pathToSave + "\\" + "Entrada_Assistencia_Id_" + id;

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    if (!Directory.Exists(pathToSave))
                    {
                        Directory.CreateDirectory(pathToSave);
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAsync(int id)
        {
            _entradaAssistenciaTecnicaService.DeleteDocument(id);


            //var document = await _entradaAssistenciaTecnicaService.ReadOneDocumentAsync(id);
            //if (document == null)
            //    return NotFound();

            //_entradaAssistenciaTecnicaService.DeleteDocument(document);


            return NoContent();
        }
    }
}