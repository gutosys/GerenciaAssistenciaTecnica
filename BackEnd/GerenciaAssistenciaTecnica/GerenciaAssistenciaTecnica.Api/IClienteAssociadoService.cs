using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IClienteAssociadoService
    {
        Task<ClienteAssociado> CreateAsync(ClienteAssociado clienteAssociado);

        Task DeleteAsync(ClienteAssociado clienteAssociado);

        bool IsClienteAssociadoExistsAsync(int clienteAssociadoId);

        Task<IEnumerable<ClienteAssociado>> ReadAllAsync();

        Task<ClienteAssociado> ReadOneAsync(int id);

        Task UpdateAsync(ClienteAssociado clienteAssociado);
    }
}
