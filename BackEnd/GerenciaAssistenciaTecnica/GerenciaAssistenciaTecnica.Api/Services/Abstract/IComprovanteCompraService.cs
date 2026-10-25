using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Abstract
{
    public interface IComprovanteCompraService
    {
        Task<ComprovanteCompra> CreateAsync(ComprovanteCompra comprovanteCompra);

        Task DeleteAsync(ComprovanteCompra comprovanteCompra);

        bool IsComprovanteCompraExistsAsync(int comprovanteCompraId);

        Task<IEnumerable<ComprovanteCompra>> ReadAllAsync();

        Task<ComprovanteCompra> ReadOneAsync(int id);

        Task UpdateAsync(ComprovanteCompra comprovanteCompra);
    }
}
