using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IAcessorioAssistenciaService
    {
        Task CreateAsync(int entradaAssistenciaId, ICollection<AcessorioMaquinaAssistencia>  acessorioList);

        //void Delete(EntradaAssistenciaTecnica entradaAssistenciaTecnica);

        //bool IsEntradaAssistenciaTecnicaExistsAsync(int entradaAssistenciaTecnicaId);

        //Task<IEnumerable<EntradaAssistenciaTecnica>> ReadAllAsync();

        //Task<EntradaAssistenciaTecnica> ReadOneAsync(int id);

        //Task UpdateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica);
    }
}
