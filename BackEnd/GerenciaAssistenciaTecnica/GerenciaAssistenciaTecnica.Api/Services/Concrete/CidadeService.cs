using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
        }

        public Task<Cidade> CreateAsync(Cidade cidade)
        {
            return _cidadeRepository.AddAsync(cidade);
        }

        public async Task DeleteAsync(Cidade cidade)
        {
            await _cidadeRepository.DeleteAsync(cidade);
        }

        public bool IsCidadeExistsAsync(int id)
        {
            return _cidadeRepository.IsCidadeExistsAsync(id);
        }

        public async Task<IEnumerable<Cidade>> ReadAllAsync()
        {
            return await _cidadeRepository.ListAllAsync();
        }

        public async Task<Cidade> ReadOneAsync(int id)
        {
            return await _cidadeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Cidade cidade)
        {
            await _cidadeRepository.UpdateAsync(cidade);
        }
    }
}
