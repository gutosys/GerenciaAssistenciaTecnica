using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private GerenciaAssistenciaTecnicaContext _dbContext;

        public EstadoRepository(GerenciaAssistenciaTecnicaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Estado>> ListAsync()
        {
            //return await _dbContext.Estados.Include(e => e.Cidades).ToListAsync();
            return await _dbContext.Estados.OrderBy(x => x.Descricao).ToListAsync();
        }
    }
}
