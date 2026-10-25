using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class CidadeRepository : EfRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {   
        }

        public bool IsCidadeExistsAsync(int id)
        {
            return _dbContext.Cidades.Any(t => t.Id == id);
        }

        public List<Cidade> ReadListByEstado(int estadoId)
        {
            return _dbContext.Cidades.Where(x => x.EstadoId == estadoId).OrderBy(x => x.Descricao).ToList();
        }
    }
}
