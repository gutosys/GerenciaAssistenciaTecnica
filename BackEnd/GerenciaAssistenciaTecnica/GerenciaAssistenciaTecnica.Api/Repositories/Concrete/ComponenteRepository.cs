using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class ComponenteRepository : EfRepository<Componente>, IComponenteRepository
    {
        public ComponenteRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {

        }

        public bool IsComponenteExistsAsync(int id)
        {
            return _dbContext.Componentes.Any(t => t.Id == id);
        }

        public async Task<Componente> AddAsync(Componente componente)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Componentes.Add(componente);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return componente;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<Componente> UpdateAsync(Componente componente)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Componentes.Update(componente);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return componente;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Componente>> ReadAllAsync()
        {
            return await _dbContext.Componentes.ToListAsync();
        }

        public async Task<Componente> GetByIdAsync(int id)
        {
            return await _dbContext.Componentes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Delete(Componente componente)
        {
            try
            {
                _dbContext.Componentes.Remove(componente);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }
    }
}
