using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class RegimeTributarioRepository : EfRepository<RegimeTributario>, IRegimeTributarioRepository
    {
        public RegimeTributarioRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {   
        }

        public bool IsRegimeTributarioExistsAsync(int id)
        {
            return _dbContext.RegimeTributarios.Any(t => t.Id == id);
        }
    }
}
