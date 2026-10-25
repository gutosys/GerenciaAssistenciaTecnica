using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Abstract
{
    public interface IEntreguePorService
    {
        Task<EntreguePor> CreateAsync(EntreguePor entreguePor);

        Task DeleteAsync(EntreguePor entreguePor);

        bool IsEntreguePorExistsAsync(int entreguePorId);

        Task<IEnumerable<EntreguePor>> ReadAllAsync();

        Task<EntreguePor> ReadOneAsync(int id);

        Task UpdateAsync(EntreguePor entreguePor);
    }
}
