using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Abstract
{
    public interface IAcessorioRepository : IAsyncRepository<Acessorio>
    {
        bool IsAcessorioExistsAsync(int id);
    }
}
