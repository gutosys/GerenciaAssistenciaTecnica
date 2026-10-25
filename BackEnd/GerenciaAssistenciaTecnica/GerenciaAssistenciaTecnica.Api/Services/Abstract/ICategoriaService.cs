using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface ICategoriaService
    {
        Task<Categoria> CreateAsync(Categoria categoria);

        Task DeleteAsync(Categoria categoria);

        bool IsCategoriaExistsAsync(int categoriaId);

        Task<IEnumerable<Categoria>> ReadAllAsync();

        Task<Categoria> ReadOneAsync(int id);

        Task UpdateAsync(Categoria categoria);
    }
}
