using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class MaquinaService : IMaquinaService
    {
        private readonly IMaquinaRepository _maquinaRepository;

        public MaquinaService(IMaquinaRepository maquinaRepository)
        {
            _maquinaRepository = maquinaRepository ?? throw new ArgumentNullException(nameof(maquinaRepository));
        }

        public Task<Maquina> CreateAsync(Maquina maquina)
        {
            return _maquinaRepository.AddAsync(maquina);            
        }

        public async  Task DeleteAsync(Maquina maquina)
        {
            await _maquinaRepository.DeleteAsync(maquina);
        }

        public bool IsMaquinaExistsAsync(int id)
        {
            return _maquinaRepository.IsMaquinaExistsAsync(id);
        }

        public async Task<IEnumerable<Maquina>> ReadAllAsync()
        {
            return await _maquinaRepository.ListAllAsync();
        }

        public async Task<Maquina> ReadOneAsync(int id)
        {
            return await _maquinaRepository.GetByIdAsync(id);            
        }

        public async Task UpdateAsync(Maquina maquina)
        {
            await _maquinaRepository.UpdateAsync(maquina);
        }
    }
}
