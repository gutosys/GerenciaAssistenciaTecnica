using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class FuncionarioRepository : EfRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }       

        public bool IsFuncionarioExistsAsync(int id)
        {
            return _dbContext.PessoaFisicas.Any(t => t.Id == id);
        }

        public async Task<Funcionario> AddAsync(Funcionario funcionario)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Funcionarios.Add(funcionario);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return funcionario;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }


        public async Task<IEnumerable<Funcionario>> ReadAllAsync()
        {
            return await _dbContext.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> UpdateAsync(Funcionario funcionario)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Funcionarios.Update(funcionario);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return funcionario;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }
    }
}
