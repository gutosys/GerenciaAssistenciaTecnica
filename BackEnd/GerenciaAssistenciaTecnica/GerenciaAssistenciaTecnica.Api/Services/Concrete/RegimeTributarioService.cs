using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class RegimeTributarioService : IRegimeTributarioService
    {
        private readonly IRegimeTributarioRepository _regimeTributarioRepository;

        public RegimeTributarioService(IRegimeTributarioRepository regimeTributarioRepository)
        {
            _regimeTributarioRepository = regimeTributarioRepository ?? throw new ArgumentNullException(nameof(regimeTributarioRepository));
        }

        public Task<RegimeTributario> CreateAsync(RegimeTributario regimeTributario)
        {
            return _regimeTributarioRepository.AddAsync(regimeTributario);            
        }

        public async  Task DeleteAsync(RegimeTributario regimeTributario)
        {
            await _regimeTributarioRepository.DeleteAsync(regimeTributario);
        }

        public bool IsRegimeTributarioExistsAsync(int id)
        {
            return _regimeTributarioRepository.IsRegimeTributarioExistsAsync(id);
        }

        public async Task<IEnumerable<RegimeTributario>> ReadAllAsync()
        {
            return await _regimeTributarioRepository.ListAllAsync();
        }

        public async Task<RegimeTributario> ReadOneAsync(int id)
        {
            return await _regimeTributarioRepository.GetByIdAsync(id);            
        }

        public async Task UpdateAsync(RegimeTributario regimeTributario)
        {
            await _regimeTributarioRepository.UpdateAsync(regimeTributario);
        }
    }
}
