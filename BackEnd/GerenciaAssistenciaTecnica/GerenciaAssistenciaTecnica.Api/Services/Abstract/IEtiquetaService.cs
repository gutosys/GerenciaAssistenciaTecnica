using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Abstract
{
    public interface IEtiquetaService
    {
        Task<Etiqueta> CreateAsync(Etiqueta etiqueta);

        Task DeleteAsync(Etiqueta etiqueta);

        bool IsEtiquetaExistsAsync(int etiquetaId);

        Task<IEnumerable<Etiqueta>> ReadAllAsync();

        Task<Etiqueta> ReadOneAsync(int id);

        Task UpdateAsync(Etiqueta etiqueta);
    }
}
