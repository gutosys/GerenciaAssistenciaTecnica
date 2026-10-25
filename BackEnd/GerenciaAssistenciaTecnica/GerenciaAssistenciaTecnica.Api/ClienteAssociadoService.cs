using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class ClienteAssociadoService : IClienteAssociadoService
    {
        private readonly IClienteAssociadoRepository _clienteAssociadoRepository;

        public ClienteAssociadoService(IClienteAssociadoRepository clienteAssociadoRepository)
        {
            _clienteAssociadoRepository = clienteAssociadoRepository ?? throw new ArgumentNullException(nameof(clienteAssociadoRepository));
        }

        public Task<ClienteAssociado> CreateAsync(ClienteAssociado clienteAssociado)
        {
            return _clienteAssociadoRepository.AddAsync(clienteAssociado);
        }

        public async Task DeleteAsync(ClienteAssociado clienteAssociado)
        {
            await _clienteAssociadoRepository.DeleteAsync(clienteAssociado);
        }

        public bool IsClienteAssociadoExistsAsync(int id)
        {
            return _clienteAssociadoRepository.IsClienteAssociadoExistsAsync(id);
        }

        public async Task<IEnumerable<ClienteAssociado>> ReadAllAsync()
        {
            return await _clienteAssociadoRepository.ReadAllAsync();
        }

        public async Task<ClienteAssociado> ReadOneAsync(int id)
        {
            return await _clienteAssociadoRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ClienteAssociado clienteAssociado)
        {
            await _clienteAssociadoRepository.UpdateAsync(clienteAssociado);
        }
    }
}
