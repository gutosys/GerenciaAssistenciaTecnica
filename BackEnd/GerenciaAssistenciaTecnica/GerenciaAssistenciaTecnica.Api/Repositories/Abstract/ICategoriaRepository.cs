using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface ICategoriaRepository : IAsyncRepository<Categoria>
    {
        bool IsCategoriaExistsAsync(int id);
    }
}
