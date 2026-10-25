using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IEstoqueService
    {
        Task<Estoque> CreateAsync(Estoque estoque);

        void Delete(Estoque estoque);

        bool IsEstoqueExistsAsync(int estoqueId);

        Task<IEnumerable<Estoque>> ReadAllAsync();

        Task<Estoque> ReadOneAsync(int id);

        Task UpdateAsync(Estoque estoque);
    }
}
