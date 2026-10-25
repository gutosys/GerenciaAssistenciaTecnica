using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IMaquinaRepository : IAsyncRepository<Maquina>
    {
        bool IsMaquinaExistsAsync(int id);
    }
}
