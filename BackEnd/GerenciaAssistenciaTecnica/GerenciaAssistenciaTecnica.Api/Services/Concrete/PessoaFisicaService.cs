using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository ?? throw new ArgumentNullException(nameof(pessoaFisicaRepository));
        }

        public async Task<PessoaFisica> CreateAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente)
        {
            try
            {

                return await _pessoaFisicaRepository.AddAsync(pessoaFisica, endereco, cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(PessoaFisica pessoaFisica)
        {
            _pessoaFisicaRepository.Delete(pessoaFisica);
        }

        public bool IsPessoaFisicaExistsAsync(int id)
        {
            return _pessoaFisicaRepository.IsPessoaFisicaExistsAsync(id);
        }

        public bool IsCpfExistsAsync(string cpf)
        {
            return _pessoaFisicaRepository.IsCpfExistsAsync(cpf);
        }

        public async Task<IEnumerable<PessoaFisica>> ReadAllAsync()
        {
            return await _pessoaFisicaRepository.ReadAllAsync();
        }

        public async Task<PessoaFisica> ReadOneAsync(int id)
        {
            return await _pessoaFisicaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente)
        {
            await _pessoaFisicaRepository.UpdateAsync(pessoaFisica, endereco, cliente);
        }
    }
}
