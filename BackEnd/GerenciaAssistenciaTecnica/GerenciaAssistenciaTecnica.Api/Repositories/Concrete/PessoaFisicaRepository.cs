using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class PessoaFisicaRepository : EfRepository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {   
        }

        public bool IsPessoaFisicaExistsAsync(int id)
        {
            return _dbContext.PessoaFisicas.Any(t => t.Id == id);
        }
        
        public bool IsCpfExistsAsync(string cpf)
        {
            return _dbContext.PessoaFisicas.Any(t => t.Cpf == cpf);
        }

        public async Task<PessoaFisica> AddAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Enderecos.Add(endereco);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Clientes.Add(cliente);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.PessoaFisicas.Add(pessoaFisica);
                    await _dbContext.SaveChangesAsync();                    

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return  pessoaFisica;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<PessoaFisica> UpdateAsync(PessoaFisica pessoaFisica, Endereco endereco, Cliente cliente)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Enderecos.Update(endereco);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Clientes.Update(cliente);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.PessoaFisicas.Update(pessoaFisica);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return pessoaFisica;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<PessoaFisica>> ReadAllAsync()
        {
            return await _dbContext.PessoaFisicas.Include(x => x.Cliente).Include(x=> x.Cliente.Endereco).ToListAsync();
        }
        
        public async Task<PessoaFisica> GetByIdAsync(int id)
        {
            return await _dbContext.PessoaFisicas.Include(x => x.Cliente).Include(x => x.Cliente.Endereco).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Delete(PessoaFisica pessoaFisica)
        {
            try
            {
                _dbContext.PessoaFisicas.Remove(pessoaFisica);
                _dbContext.SaveChanges();

                _dbContext.Clientes.Remove(pessoaFisica.Cliente);
                _dbContext.SaveChanges();

                _dbContext.Enderecos.Remove(pessoaFisica.Cliente.Endereco);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw;
            }
            
        }        
    }
}
