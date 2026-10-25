using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IAcessorioAssistenciaRepository : IAsyncRepository<AcessorioMaquinaAssistencia>
    {
        Task AddAsync(int entradaAssistenciaId, ICollection<AcessorioMaquinaAssistencia> acessorioList);
    }
}
