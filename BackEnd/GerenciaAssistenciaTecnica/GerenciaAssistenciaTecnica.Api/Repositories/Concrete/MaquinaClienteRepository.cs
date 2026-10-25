using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class MaquinaClienteRepository : EfRepository<MaquinaCliente>, IMaquinaClienteRepository
    {
        public MaquinaClienteRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsMaquinaClienteExistsAsync(int id)
        {
            return _dbContext.MaquinaClientes.Any(t => t.Id == id);
        }
    }
}
