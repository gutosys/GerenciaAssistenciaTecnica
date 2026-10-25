using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface ICidadeService
    {
        Task<Cidade> CreateAsync(Cidade cidade);

        Task DeleteAsync(Cidade cidade);

        bool IsCidadeExistsAsync(int cidadeId);

        Task<IEnumerable<Cidade>> ReadAllAsync();

        Task<Cidade> ReadOneAsync(int id);

        Task UpdateAsync(Cidade cidade);        
    }
}
