using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class EstoqueRepository : EfRepository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsEstoqueExistsAsync(int id)
        {
            return _dbContext.Estoques.Any(t => t.Id == id);
        }

        public async Task<Estoque> AddAsync(Estoque estoque)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Estoques.Add(estoque);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return estoque;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Estoque> UpdateAsync(Estoque estoque)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Estoques.Update(estoque);
                    await _dbContext.SaveChangesAsync();                    

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return estoque;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<Estoque>> ReadAllAsync()
        {
            return await _dbContext.Estoques.Include(x => x.Componente).ToListAsync();
        }

        public async Task<Estoque> GetByIdAsync(int id)
        {
            return await _dbContext.Estoques.Include(x => x.Componente).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Delete(Estoque estoque)
        {
            try
            {
                _dbContext.Estoques.Remove(estoque);
                _dbContext.SaveChanges();                
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
