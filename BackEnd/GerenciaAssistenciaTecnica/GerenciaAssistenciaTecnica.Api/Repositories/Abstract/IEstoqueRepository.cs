using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IEstoqueRepository : IAsyncRepository<Estoque>
    {
        bool IsEstoqueExistsAsync(int id);

        Task<Estoque> AddAsync(Estoque estoque);

        Task<Estoque> UpdateAsync(Estoque estoque);

        Task<IEnumerable<Estoque>> ReadAllAsync();

        Task<Estoque> GetByIdAsync(int id);

        void Delete(Estoque estoque);
    }
}
