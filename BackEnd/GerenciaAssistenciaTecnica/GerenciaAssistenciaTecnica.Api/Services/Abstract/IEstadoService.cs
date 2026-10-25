using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IEstadoService
    {
        Task<IEnumerable<Estado>> ReadAllAsync();
    }
}
