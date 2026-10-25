using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IClienteAssociadoRepository : IAsyncRepository<ClienteAssociado>
    {
        bool IsClienteAssociadoExistsAsync(int id);
        Task<IEnumerable<ClienteAssociado>> ReadAllAsync();
        List<ClienteAssociado> ReadListByPessoaJuridica(int pessoaJuridicaId);
    }
}
