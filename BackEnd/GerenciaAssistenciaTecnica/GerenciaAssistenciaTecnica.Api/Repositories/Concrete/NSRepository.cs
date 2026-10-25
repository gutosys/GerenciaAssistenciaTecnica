using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class NSRepository : EfRepository<EntradaAssistenciaTecnica>, INSRepository
    {
        public NSRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool NSExists(string ns, string Ns)
        {
            return _dbContext.EntradaAssistenciaTecnicas.Any(t => t.NS== ns);
        }
    }
}
