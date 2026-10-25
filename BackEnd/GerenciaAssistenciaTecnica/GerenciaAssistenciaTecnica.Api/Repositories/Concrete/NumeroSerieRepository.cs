using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class NumeroSerieRepository : EfRepository<EntradaAssistenciaTecnica>, INumeroSerieRepository
    {
        public NumeroSerieRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool NumeroSerieExists(string numeroSerie, string numeroProtocoloTroca)
        {
            return _dbContext.EntradaAssistenciaTecnicas.Any(t => t.NumeroSerie == numeroSerie);
        }
    }
}
