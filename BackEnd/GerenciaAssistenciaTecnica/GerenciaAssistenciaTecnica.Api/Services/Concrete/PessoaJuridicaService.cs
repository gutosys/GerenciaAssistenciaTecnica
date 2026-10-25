using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;

        public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository ?? throw new ArgumentNullException(nameof(pessoaJuridicaRepository));
        }

        public async Task<PessoaJuridica> CreateAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente)
        {
            return await _pessoaJuridicaRepository.AddAsync(pessoaJuridica, endereco, cliente);
        }

        public void Delete(PessoaJuridica pessoaJuridica)
        {
            _pessoaJuridicaRepository.Delete(pessoaJuridica);
        }

        public bool IsPessoaJuridicaExistsAsync(int id)
        {
            return _pessoaJuridicaRepository.IsPessoaJuridicaExistsAsync(id);
        }
        
        public bool IsCnpjExistsAsync(string cnpj)
        {
            return _pessoaJuridicaRepository.IsCnpjExistsAsync(cnpj);
        }

        public async Task<IEnumerable<PessoaJuridica>> ReadAllAsync()
        {
            return await _pessoaJuridicaRepository.ReadAllAsync();
        }

        public async Task<PessoaJuridica> ReadOneAsync(int id)
        {
            return await _pessoaJuridicaRepository.GetByIdAsync(id);            
        }

        public async Task UpdateAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente)
        {
            await _pessoaJuridicaRepository.UpdateAsync(pessoaJuridica, endereco, cliente);
        }
    }
}
