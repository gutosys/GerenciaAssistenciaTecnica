using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class AcessorioAssistenciaRepository : EfRepository<AcessorioMaquinaAssistencia>, IAcessorioAssistenciaRepository
    {
        public AcessorioAssistenciaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {

        }

        public async Task AddAsync(int entradaAssistenciaId, ICollection<AcessorioMaquinaAssistencia> acessorioList)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var acessorio in acessorioList)
                    {
                        acessorio.EntradaAssistenciaTecnicaId = entradaAssistenciaId;
                       // _dbContext.AcessorioMaquinaAssistencias.Add(acessorio);
                    }

                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();                    
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }

        public Task<AcessorioMaquinaAssistencia> AddAsync(AcessorioMaquinaAssistencia entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(ISpecification<AcessorioMaquinaAssistencia> spec)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AcessorioMaquinaAssistencia entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<AcessorioMaquinaAssistencia>> ListAsync(ISpecification<AcessorioMaquinaAssistencia> spec)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AcessorioMaquinaAssistencia entity)
        {
            throw new NotImplementedException();
        }

        Task<AcessorioMaquinaAssistencia> IAsyncRepository<AcessorioMaquinaAssistencia>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<AcessorioMaquinaAssistencia>> IAsyncRepository<AcessorioMaquinaAssistencia>.ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
