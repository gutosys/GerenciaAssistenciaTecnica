using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class MaquinaRepository : EfRepository<Maquina>, IMaquinaRepository
    {
        public MaquinaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {   
        }

        public bool IsMaquinaExistsAsync(int id)
        {
            return _dbContext.Maquinas.Any(t => t.Id == id);
        }
    }
}
