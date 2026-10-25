using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IEntradaAssistenciaTecnicaService
    {
        Task<EntradaAssistenciaTecnica> CreateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica);

        Task CreateEntradaAssistenciaDescricaoAsync(int entradaAssistenciaTecnicaId, string descricao, int entradaAssistenciaStatus);

        Task CreateEntradaAssistenciaAcessorioAsync(int entradaAssistenciaTecnicaId, List<int> entradaAssistenciaAcessorios);        

        Task DeleteEntradaAssistenciaDescricaoAsync(int entradaAssistenciaTecnicaId);
        void Delete(EntradaAssistenciaTecnica entradaAssistenciaTecnica);        
        void DeleteDocument(int entradaAssistenciaTecnicaId);

        bool IsEntradaAssistenciaTecnicaExistsAsync(int entradaAssistenciaTecnicaId);

        Task<IEnumerable<EntradaAssistenciaTecnica>> ReadAllAsync();

        EntradaAssistenciaTecnica ReadOneAsync(int id);

        Task UpdateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica);

        Task SaveDocumentsToDatabase(int entradaAssistenciaId);
    }
}
