using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IPessoaJuridicaService
    {
        Task<PessoaJuridica> CreateAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente);

        void Delete(PessoaJuridica pessoaJuridica);

        bool IsPessoaJuridicaExistsAsync(int pessoaJuridicaId);

        bool IsCnpjExistsAsync(string cnpj);        

        Task<IEnumerable<PessoaJuridica>> ReadAllAsync();

        Task<PessoaJuridica> ReadOneAsync(int id);

        Task UpdateAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente);        
    }
}
