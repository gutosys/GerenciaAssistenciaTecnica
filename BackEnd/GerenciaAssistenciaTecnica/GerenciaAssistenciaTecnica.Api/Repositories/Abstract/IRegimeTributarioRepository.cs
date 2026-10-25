using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IRegimeTributarioRepository : IAsyncRepository<RegimeTributario>
    {
        bool IsRegimeTributarioExistsAsync(int id);
    }
}
