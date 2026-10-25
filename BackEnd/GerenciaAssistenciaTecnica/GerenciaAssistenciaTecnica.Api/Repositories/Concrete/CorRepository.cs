using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class CorRepository : EfRepository<Cor>, ICorRepository
    {
        public CorRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsCorExistsAsync(int id)
        {
            return _dbContext.Cores.Any(t => t.Id == id);
        }

        public List<Cor> ReadList()
        {
            return _dbContext.Cores.ToList();
        }
    }
}
