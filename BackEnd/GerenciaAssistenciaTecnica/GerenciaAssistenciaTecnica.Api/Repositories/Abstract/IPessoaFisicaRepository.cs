using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IPessoaFisicaRepository : IAsyncRepository<PessoaFisica>
    {
        bool IsPessoaFisicaExistsAsync(int id);

        bool IsCpfExistsAsync(string cpf);

        Task<PessoaFisica> AddAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente);

        Task<PessoaFisica> UpdateAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente);

        Task<IEnumerable<PessoaFisica>> ReadAllAsync();

        Task<PessoaFisica> GetByIdAsync(int id);

        void Delete(PessoaFisica pessoaFisica);
    }
}
