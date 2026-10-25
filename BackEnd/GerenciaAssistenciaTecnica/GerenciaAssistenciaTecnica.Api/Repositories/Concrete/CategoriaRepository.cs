using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class CategoriaRepository : EfRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsCategoriaExistsAsync(int id)
        {
            return _dbContext.Categorias.Any(t => t.Id == id);
        }
    }
}
