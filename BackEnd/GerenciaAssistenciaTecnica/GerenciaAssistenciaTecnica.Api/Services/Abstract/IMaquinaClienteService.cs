using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IMaquinaClienteService
    {
        Task<MaquinaCliente> CreateAsync(MaquinaCliente maquinaCliente);

        Task DeleteAsync(MaquinaCliente maquinaCliente);

        bool IsMaquinaClienteExistsAsync(int maquinaClienteId);

        Task<IEnumerable<MaquinaCliente>> ReadAllAsync();

        Task<MaquinaCliente> ReadOneAsync(int id);

        Task UpdateAsync(MaquinaCliente maquinaCliente);
    }
}
