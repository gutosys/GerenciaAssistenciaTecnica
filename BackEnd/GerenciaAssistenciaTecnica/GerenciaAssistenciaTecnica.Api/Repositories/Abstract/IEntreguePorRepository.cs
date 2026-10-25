using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Abstract
{
    public interface IEntreguePorRepository : IAsyncRepository<EntreguePor>
    {
        Task<IEnumerable<EntreguePor>> ReadAllAsync();

        bool IsEntreguePorExistsAsync(int id);
    }
}
