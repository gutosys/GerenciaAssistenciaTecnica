using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IEntradaAssistenciaTecnicaRepository : IAsyncRepository<EntradaAssistenciaTecnica>
    {
        bool IsEntradaAssistenciaTecnicaExistsAsync(int id);

        Task<EntradaAssistenciaTecnica> AddAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica);

        Task<EntradaAssistenciaTecnica> UpdateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica);

        Task CreateEntradaAssistenciaDescricaoAsync(int entradaAssistenciaTecnicaId, string descricao, int entradaAssistenciaStatus);

        Task CreateEntradaAssistenciaAcessorioAsync(int entradaAssistenciaTecnicaId, List<int> entradaAssistenciaAcesorioList);
        
        Task<IEnumerable<EntradaAssistenciaTecnica>> ReadAllAsync();

        Task<IEnumerable<EntradaAssistenciaTecnica>> ReadBoardAsync();

        EntradaAssistenciaTecnica GetByIdAsync(int id);

        Task<bool> UpdateStatusAsync(int id, int statusId);

        void Delete(EntradaAssistenciaTecnica entradaAssistenciaTecnica);

        void DeleteDocument(int entradaAssistenciaTecnicaDocumentoId);

        Task DeleteDescricao(int entradaAssistenciaTecnicaId);

        Task SaveFileEntradaOcorrencia(int entradaAssistenciaId, Byte[] file, string fileName);
    }
}
