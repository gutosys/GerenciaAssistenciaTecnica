using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Concrete
{
    public class EtiquetaRepository : EfRepository<Etiqueta>, IEtiquetaRepository
    {
        public EtiquetaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Etiqueta>> ReadAllAsync()
        {
            return _dbContext.Etiquetas
                             .Include(x => x.Cor);
        }

        public bool IsEtiquetaExistsAsync(int id)
        {
            return _dbContext.Etiquetas.Any(t => t.Id == id);
        }
    }
}
