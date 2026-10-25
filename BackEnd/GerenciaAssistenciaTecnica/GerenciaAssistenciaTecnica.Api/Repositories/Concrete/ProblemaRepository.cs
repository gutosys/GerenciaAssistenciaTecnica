using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class ProblemaRepository : EfRepository<Problema>, IProblemaRepository
    {
        public ProblemaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsProblemaExistsAsync(int id)
        {
            return _dbContext.Problemas.Any(t => t.Id == id);
        }
    }
}
