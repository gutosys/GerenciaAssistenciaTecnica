using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IPessoaFisicaService
    {
        Task<PessoaFisica> CreateAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente);

        void Delete(PessoaFisica pessoaFisica);

        bool IsPessoaFisicaExistsAsync(int pessoaFisicaId);
        
        bool IsCpfExistsAsync(string cpf);

        Task<IEnumerable<PessoaFisica>> ReadAllAsync();

        Task<PessoaFisica> ReadOneAsync(int id);

        Task UpdateAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente);        
    }
}
