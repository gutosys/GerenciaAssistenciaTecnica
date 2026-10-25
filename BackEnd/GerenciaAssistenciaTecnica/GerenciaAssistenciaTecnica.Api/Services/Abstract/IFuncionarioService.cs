using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IFuncionarioService
    {
        Task<Funcionario> CreateAsync(Funcionario funcionario);

        Task DeleteAsync(Funcionario funcionario);

        bool IsFuncionarioExistsAsync(int funcionarioId);

        Task<IEnumerable<Funcionario>> ReadAllAsync();

        Task<Funcionario> ReadOneAsync(int id);

        Task UpdateAsync(Funcionario funcionario);
    }
}
