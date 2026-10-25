using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IRegimeTributarioService
    {
        Task<RegimeTributario> CreateAsync(RegimeTributario regimeTributario);

        Task DeleteAsync(RegimeTributario regimeTributario);

        bool IsRegimeTributarioExistsAsync(int regimeTributarioId);

        Task<IEnumerable<RegimeTributario>> ReadAllAsync();

        Task<RegimeTributario> ReadOneAsync(int id);

        Task UpdateAsync(RegimeTributario regimeTributario);        
    }
}
