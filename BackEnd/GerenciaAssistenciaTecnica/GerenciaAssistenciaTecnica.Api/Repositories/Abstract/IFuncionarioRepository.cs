using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IFuncionarioRepository : IAsyncRepository<Funcionario>
    {
        bool IsFuncionarioExistsAsync(int id);

        Task<Funcionario> AddAsync(Funcionario funcionario);

        Task<Funcionario> UpdateAsync(Funcionario funcionario);

        Task<IEnumerable<Funcionario>> ReadAllAsync();

        Task<Funcionario> GetByIdAsync(int id);        
    }
}
