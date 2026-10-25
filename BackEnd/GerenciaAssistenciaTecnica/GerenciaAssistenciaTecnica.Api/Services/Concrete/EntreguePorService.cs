using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class EntreguePorService : IEntreguePorService
    {
        private readonly IEntreguePorRepository _entreguePorRepository;

        public EntreguePorService(IEntreguePorRepository entreguePorRepository)
        {
            _entreguePorRepository = entreguePorRepository ?? throw new ArgumentNullException(nameof(entreguePorRepository));
        }

        public Task<EntreguePor> CreateAsync(EntreguePor entreguePor)
        {
            return _entreguePorRepository.AddAsync(entreguePor);
        }

        public async Task DeleteAsync(EntreguePor entreguePor)
        {
            await _entreguePorRepository.DeleteAsync(entreguePor);
        }

        public bool IsEntreguePorExistsAsync(int id)
        {
            return _entreguePorRepository.IsEntreguePorExistsAsync(id);
        }

        public async Task<IEnumerable<EntreguePor>> ReadAllAsync()
        {
            return await _entreguePorRepository.ReadAllAsync();
        }

        public async Task<EntreguePor> ReadOneAsync(int id)
        {
            return await _entreguePorRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(EntreguePor entreguePor)
        {
            await _entreguePorRepository.UpdateAsync(entreguePor);
        }
    }
}
