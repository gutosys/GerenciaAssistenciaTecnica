using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface IPessoaJuridicaRepository : IAsyncRepository<PessoaJuridica>
    {
        bool IsPessoaJuridicaExistsAsync(int id);
        
        bool IsCnpjExistsAsync(string cnpj);
        Task<PessoaJuridica> AddAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente);

        Task<PessoaJuridica> UpdateAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente);

        Task<IEnumerable<PessoaJuridica>> ReadAllAsync();

        Task<PessoaJuridica> GetByIdAsync(int id);

        void Delete(PessoaJuridica pessoaJuridica);
    }
}
