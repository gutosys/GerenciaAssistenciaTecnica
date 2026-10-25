using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class ComprovanteCompraRepository : EfRepository<ComprovanteCompra>, IComprovanteCompraRepository
    {
        public ComprovanteCompraRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ComprovanteCompra>> ReadAllAsync()
        {
            return _dbContext.ComprovanteCompras.ToList();
        }

        public bool IsComprovanteCompraExistsAsync(int id)
        {
            return _dbContext.ComprovanteCompras.Any(t => t.Id == id);
        }
    }
}
