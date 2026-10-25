using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class EntradaAssistenciaTecnicaService : IEntradaAssistenciaTecnicaService
    {
        private readonly IEntradaAssistenciaTecnicaRepository _entradaAssistenciaTecnicaRepository;

        public EntradaAssistenciaTecnicaService(IEntradaAssistenciaTecnicaRepository entradaAssistenciaTecnicaRepository)
        {
            this._entradaAssistenciaTecnicaRepository = entradaAssistenciaTecnicaRepository;
        }

        public async Task<EntradaAssistenciaTecnica> CreateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica)
        {
            try
            {

                return await _entradaAssistenciaTecnicaRepository.AddAsync(entradaAssistenciaTecnica);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(EntradaAssistenciaTecnica entradaAssistenciaTecnica)
        {
            _entradaAssistenciaTecnicaRepository.Delete(entradaAssistenciaTecnica);
        }

        public bool IsEntradaAssistenciaTecnicaExistsAsync(int entradaAssistenciaTecnicaId)
        {
            return _entradaAssistenciaTecnicaRepository.IsEntradaAssistenciaTecnicaExistsAsync(entradaAssistenciaTecnicaId);
        }

        public async Task<IEnumerable<EntradaAssistenciaTecnica>> ReadAllAsync()
        {
            return await _entradaAssistenciaTecnicaRepository.ReadAllAsync();
        }

        public EntradaAssistenciaTecnica ReadOneAsync(int id)
        {
            return _entradaAssistenciaTecnicaRepository.GetByIdAsync(id);
        }

        public async Task SaveDocumentsToDatabase(int entradaAssistenciaId)
        {
            //Verifica se existem arquivos no diretório

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var pathToCheck = pathToSave + "\\" + "Entrada_Assistencia_Id_" + entradaAssistenciaId;

            await SaveFilesInDatabase(entradaAssistenciaId, pathToCheck);
        }

        private async Task SaveFilesInDatabase(int entradaAssistenciaId, string pathToCheck)
        {
            if (Directory.Exists(pathToCheck))
            {
                DirectoryInfo directory = new DirectoryInfo(pathToCheck);

                foreach (var fileElement in directory.GetFiles())
                {
                    byte[] file;
                    using (var stream = new FileStream(fileElement.FullName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int)stream.Length);
                        }
                    }

                    if (file.Length > 0)
                    {
                        await _entradaAssistenciaTecnicaRepository.SaveFileEntradaOcorrencia(entradaAssistenciaId, file, fileElement.Name);
                    }
                }

                DeleteFilesAfterSaveDatabase(pathToCheck);
            }
        }

        private static void DeleteFilesAfterSaveDatabase(string pathToCheck)
        {
            var di = new DirectoryInfo(pathToCheck);

            foreach (FileInfo fileToDelete in di.GetFiles())
            {
                fileToDelete.Delete();
            }

            Directory.Delete(pathToCheck);
        }

        public async Task UpdateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica)
        {
            await _entradaAssistenciaTecnicaRepository.UpdateAsync(entradaAssistenciaTecnica);
        }

        public void DeleteDocument(int entradaAssistenciaTecnicaDocumentoId)
        {
            _entradaAssistenciaTecnicaRepository.DeleteDocument(entradaAssistenciaTecnicaDocumentoId);
        }

        public async Task DeleteEntradaAssistenciaDescricaoAsync(int entradaAssistenciaTecnicaId)
        {
            await _entradaAssistenciaTecnicaRepository.DeleteDescricao(entradaAssistenciaTecnicaId);
        }

        public async Task CreateEntradaAssistenciaDescricaoAsync(int entradaAssistenciaTecnicaId, string descricao, int entradaAssistenciaStatus)
        {
            await _entradaAssistenciaTecnicaRepository.CreateEntradaAssistenciaDescricaoAsync(entradaAssistenciaTecnicaId, descricao, entradaAssistenciaStatus);
        }

        public async Task CreateEntradaAssistenciaAcessorioAsync(int entradaAssistenciaTecnicaId, List<int> entradaAssistenciaAcessorios)
        {
            await _entradaAssistenciaTecnicaRepository.CreateEntradaAssistenciaAcessorioAsync(entradaAssistenciaTecnicaId, entradaAssistenciaAcessorios);
        }
    }
}
