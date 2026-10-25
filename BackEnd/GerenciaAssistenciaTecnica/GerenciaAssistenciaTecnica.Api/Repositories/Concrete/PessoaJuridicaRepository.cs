using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class PessoaJuridicaRepository : EfRepository<PessoaJuridica>, IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {   
        }

        public bool IsPessoaJuridicaExistsAsync(int id)
        {
            return _dbContext.PessoaJuridicas.Any(t => t.Id == id);
        }
        
        public bool IsCnpjExistsAsync(string cnpj)
        {
            return _dbContext.PessoaJuridicas.Any(t => t.Cnpj == cnpj);
        }

        public async Task<PessoaJuridica> AddAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Enderecos.Add(endereco);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Clientes.Add(cliente);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.PessoaJuridicas.Add(pessoaJuridica);
                    await _dbContext.SaveChangesAsync();                    

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return pessoaJuridica;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<PessoaJuridica> UpdateAsync(PessoaJuridica pessoaJuridica, Endereco endereco, Cliente cliente)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Enderecos.Update(endereco);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Clientes.Update(cliente);
                    await _dbContext.SaveChangesAsync();

                    _dbContext.PessoaJuridicas.Update(pessoaJuridica);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return pessoaJuridica;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<PessoaJuridica>> ReadAllAsync()
        {
            return await _dbContext.PessoaJuridicas.Include(x => x.Cliente).Include(x => x.Cliente.Endereco).ToListAsync();
        }
        
        public override async Task<PessoaJuridica> GetByIdAsync(int id)
        {
            return await _dbContext.PessoaJuridicas.Include(x => x.Cliente).Include(x => x.Cliente.Endereco).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Delete(PessoaJuridica pessoaJuridica)
        {
            try
            {
                _dbContext.PessoaJuridicas.Remove(pessoaJuridica);
                _dbContext.SaveChanges();

                _dbContext.Clientes.Remove(pessoaJuridica.Cliente);
                _dbContext.SaveChanges();

                _dbContext.Enderecos.Remove(pessoaJuridica.Cliente.Endereco);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }        
    }
}
