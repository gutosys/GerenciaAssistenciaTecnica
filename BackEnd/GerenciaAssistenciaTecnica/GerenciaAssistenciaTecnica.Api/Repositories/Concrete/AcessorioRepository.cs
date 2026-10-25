using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class AcessorioRepository : EfRepository<Acessorio>, IAcessorioRepository
    {
        public AcessorioRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsAcessorioExistsAsync(int id)
        {
            return _dbContext.Acessorios.Any(t => t.Id == id);
        }
    }
}
