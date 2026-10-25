using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class ComprovanteCompraService : IComprovanteCompraService
    {
        private readonly IComprovanteCompraRepository _comprovanteCompraRepository;

        public ComprovanteCompraService(IComprovanteCompraRepository comprovanteCompraRepository)
        {
            _comprovanteCompraRepository = comprovanteCompraRepository ?? throw new ArgumentNullException(nameof(comprovanteCompraRepository));
        }

        public Task<ComprovanteCompra> CreateAsync(ComprovanteCompra comprovanteCompra)
        {
            return _comprovanteCompraRepository.AddAsync(comprovanteCompra);
        }

        public async Task DeleteAsync(ComprovanteCompra comprovanteCompra)
        {
            await _comprovanteCompraRepository.DeleteAsync(comprovanteCompra);
        }

        public bool IsComprovanteCompraExistsAsync(int id)
        {
            return _comprovanteCompraRepository.IsComprovanteCompraExistsAsync(id);
        }

        public async Task<IEnumerable<ComprovanteCompra>> ReadAllAsync()
        {
            return await _comprovanteCompraRepository.ReadAllAsync();
        }

        public async Task<ComprovanteCompra> ReadOneAsync(int id)
        {
            return await _comprovanteCompraRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ComprovanteCompra comprovanteCompra)
        {
            await _comprovanteCompraRepository.UpdateAsync(comprovanteCompra);
        }
    }
}
