using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IComponenteRepository : IAsyncRepository<Componente>
    {
        bool IsComponenteExistsAsync(int id);

        Task<Componente> AddAsync(Componente componente);

        Task<Componente> UpdateAsync(Componente componente);

        Task<IEnumerable<Componente>> ReadAllAsync();

        Task<Componente> GetByIdAsync(int id);

        void Delete(Componente componente);
    }
}
