using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class ProblemaService : IProblemaService
    {
        private readonly IProblemaRepository _problemaRepository;

        public ProblemaService(IProblemaRepository problemaRepository)
        {
            _problemaRepository = problemaRepository ?? throw new ArgumentNullException(nameof(problemaRepository));
        }

        public Task<Problema> CreateAsync(Problema problema)
        {
            return _problemaRepository.AddAsync(problema);
        }

        public async Task DeleteAsync(Problema problema)
        {
            await _problemaRepository.DeleteAsync(problema);
        }

        public bool IsProblemaExistsAsync(int id)
        {
            return _problemaRepository.IsProblemaExistsAsync(id);
        }

        public async Task<IEnumerable<Problema>> ReadAllAsync()
        {
            return await _problemaRepository.ListAllAsync();
        }

        public async Task<Problema> ReadOneAsync(int id)
        {
            return await _problemaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Problema problema)
        {
            await _problemaRepository.UpdateAsync(problema);
        }
    }
}
