using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IMaquinaService
    {
        Task<Maquina> CreateAsync(Maquina maquina);

        Task DeleteAsync(Maquina maquina);

        bool IsMaquinaExistsAsync(int maquinaId);

        Task<IEnumerable<Maquina>> ReadAllAsync();

        Task<Maquina> ReadOneAsync(int id);

        Task UpdateAsync(Maquina maquina);        
    }
}
