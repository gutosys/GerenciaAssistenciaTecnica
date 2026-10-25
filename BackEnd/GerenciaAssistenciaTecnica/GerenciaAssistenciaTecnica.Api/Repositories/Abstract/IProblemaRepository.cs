using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IProblemaRepository : IAsyncRepository<Problema>
    {
        bool IsProblemaExistsAsync(int id);
    }
}
