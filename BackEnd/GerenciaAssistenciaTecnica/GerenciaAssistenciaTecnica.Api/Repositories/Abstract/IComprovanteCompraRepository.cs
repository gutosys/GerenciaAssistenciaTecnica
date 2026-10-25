using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Abstract
{
    public interface IComprovanteCompraRepository : IAsyncRepository<ComprovanteCompra>
    {
        Task<IEnumerable<ComprovanteCompra>> ReadAllAsync();

        bool IsComprovanteCompraExistsAsync(int id);
    }
}
