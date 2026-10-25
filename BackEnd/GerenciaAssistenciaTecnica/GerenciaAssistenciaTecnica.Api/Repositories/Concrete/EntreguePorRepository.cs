using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class EntreguePorRepository : EfRepository<EntreguePor>, IEntreguePorRepository
    {
        public EntreguePorRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<EntreguePor>> ReadAllAsync()
        {
            return _dbContext.EntreguePor.ToList();
        }

        public bool IsEntreguePorExistsAsync(int id)
        {
            return _dbContext.EntreguePor.Any(t => t.Id == id);
        }
    }
}
