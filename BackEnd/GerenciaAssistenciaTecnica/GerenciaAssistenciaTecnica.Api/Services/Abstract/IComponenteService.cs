using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IComponenteService
    {
        Task<Componente> CreateAsync(Componente componente);

        void Delete(Componente componente);

        bool IsComponenteExistsAsync(int componenteId);

        Task<IEnumerable<Componente>> ReadAllAsync();

        Task<Componente> ReadOneAsync(int id);

        Task UpdateAsync(Componente componente);
    }
}
