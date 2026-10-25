using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class MaquinaClienteService : IMaquinaClienteService
    {
        private readonly IMaquinaClienteRepository _maquinaClienteRepository;

        public MaquinaClienteService(IMaquinaClienteRepository maquinaClienteRepository)
        {
            _maquinaClienteRepository = maquinaClienteRepository ?? throw new ArgumentNullException(nameof(maquinaClienteRepository));
        }

        public Task<MaquinaCliente> CreateAsync(MaquinaCliente maquinaCliente)
        {
            return _maquinaClienteRepository.AddAsync(maquinaCliente);            
        }

        public async  Task DeleteAsync(MaquinaCliente maquinaCliente)
        {
            await _maquinaClienteRepository.DeleteAsync(maquinaCliente);
        }

        public bool IsMaquinaClienteExistsAsync(int id)
        {
            return _maquinaClienteRepository.IsMaquinaClienteExistsAsync(id);
        }

        public async Task<IEnumerable<MaquinaCliente>> ReadAllAsync()
        {
            return await _maquinaClienteRepository.ListAllAsync();
        }

        public async Task<MaquinaCliente> ReadOneAsync(int id)
        {
            return await _maquinaClienteRepository.GetByIdAsync(id);            
        }

        public async Task UpdateAsync(MaquinaCliente maquinaCliente)
        {
            await _maquinaClienteRepository.UpdateAsync(maquinaCliente);
        }
    }
}
