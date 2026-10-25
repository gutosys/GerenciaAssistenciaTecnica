using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IMaquinaClienteRepository : IAsyncRepository<MaquinaCliente>
    {
        bool IsMaquinaClienteExistsAsync(int id);
    }
}
