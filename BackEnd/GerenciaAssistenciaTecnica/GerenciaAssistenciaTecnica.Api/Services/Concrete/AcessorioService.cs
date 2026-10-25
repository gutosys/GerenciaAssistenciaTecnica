using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class AcessorioService : IAcessorioService
    {
        private readonly IAcessorioRepository _acessorioRepository;

        public AcessorioService(IAcessorioRepository acessorioRepository)
        {
            _acessorioRepository = acessorioRepository ?? throw new ArgumentNullException(nameof(acessorioRepository));
        }

        public Task<Acessorio> CreateAsync(Acessorio acessorio)
        {
            return _acessorioRepository.AddAsync(acessorio);
        }

        public async Task DeleteAsync(Acessorio acessorio)
        {
            await _acessorioRepository.DeleteAsync(acessorio);
        }

        public bool IsAcessorioExistsAsync(int id)
        {
            return _acessorioRepository.IsAcessorioExistsAsync(id);
        }

        public async Task<IEnumerable<Acessorio>> ReadAllAsync()
        {
            return await _acessorioRepository.ListAllAsync();
        }

        public async Task<Acessorio> ReadOneAsync(int id)
        {
            return await _acessorioRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Acessorio acessorio)
        {
            await _acessorioRepository.UpdateAsync(acessorio);
        }
    }
}
