using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Abstract
{
    public interface IEtiquetaRepository : IAsyncRepository<Etiqueta>
    {
        Task<IEnumerable<Etiqueta>> ReadAllAsync();

        bool IsEtiquetaExistsAsync(int id);        
    }
}
