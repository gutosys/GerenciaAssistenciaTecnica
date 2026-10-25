using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class EntradaAssistenciaTecnicaRepository : EfRepository<EntradaAssistenciaTecnica>, IEntradaAssistenciaTecnicaRepository
    {
        public EntradaAssistenciaTecnicaRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsEntradaAssistenciaTecnicaExistsAsync(int id)
        {
            return _dbContext.EntradaAssistenciaTecnicas.Any(t => t.Id == id);
        }

        public async Task<EntradaAssistenciaTecnica> AddAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.EntradaAssistenciaTecnicas.Add(entradaAssistenciaTecnica);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return entradaAssistenciaTecnica;
                }
                catch (System.Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<EntradaAssistenciaTecnica> UpdateAsync(EntradaAssistenciaTecnica entradaAssistenciaTecnica)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.EntradaAssistenciaTecnicas.Update(entradaAssistenciaTecnica);
                    await _dbContext.SaveChangesAsync();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    return entradaAssistenciaTecnica;
                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<EntradaAssistenciaTecnica>> ReadAllAsync()
        {
            return _dbContext.EntradaAssistenciaTecnicas
                                 .Include(x => x.Maquina)
                                 .Include(x => x.Funcionario)
                                 .Include(x => x.PessoaFisica)
                                 .Include(x => x.PessoaJuridica)
                                 .Include(x => x.EntradaAssistenciaDescricoes)  
                                 .Include(x => x.ClienteAssociado)
                                 .Include(x => x.EntradaAssistenciaDocumentos).Where(x => x.EntradaAssistenciaStatusId == (int)EntradaAssistenciaStatusEnum.Entrada);
        }

        public EntradaAssistenciaTecnica GetByIdAsync(int id)
        {
            return _dbContext.EntradaAssistenciaTecnicas
                .Include(x => x.PessoaFisica)
                .Include(x => x.Funcionario)
                .Include(x => x.Maquina)
                .Include(x => x.PessoaJuridica)
                .Include(x => x.EntradaAssistenciaDocumentos)
                .Include(x => x.EntradaAssistenciaDescricoes)
                .Include(x => x.EntradaAssistenciaAcessorios)
                .Include(x => x.ClienteAssociado)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Delete(EntradaAssistenciaTecnica entradaAssistenciaTecnica)
        {
            try
            {
                _dbContext.EntradaAssistenciaTecnicas.Remove(entradaAssistenciaTecnica);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task SaveFileEntradaOcorrencia(int entradaAssistenciaId, byte[] file, string fileName)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    EntradaAssistenciaDocumento doc = new EntradaAssistenciaDocumento();
                    doc.EntradaAssistenciaTecnicaId = entradaAssistenciaId;
                    doc.File = file;
                    doc.FileName = fileName;

                    _dbContext.EntradaAssistenciaDocumentos.Add(doc);
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

        public void DeleteDocument(int entradaAssistenciaTecnicaDocumentoId)
        {
            try
            {
                var entradaAssistenciaTecnicaDocument = _dbContext.EntradaAssistenciaDocumentos.Where(x => x.Id == entradaAssistenciaTecnicaDocumentoId).FirstOrDefault();
                _dbContext.EntradaAssistenciaDocumentos.Remove(entradaAssistenciaTecnicaDocument);
                _dbContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteDescricao(int entradaAssistenciaTecnicaId)
        {
            try
            {
                var entradaAssistenciaTecnicaDescricao = _dbContext.EntradaAssistenciaDescricoes.Where(x => x.EntradaAssistenciaTecnicaId == entradaAssistenciaTecnicaId).FirstOrDefault();

                if (entradaAssistenciaTecnicaDescricao != null)
                {
                    _dbContext.EntradaAssistenciaDescricoes.Remove(entradaAssistenciaTecnicaDescricao);
                    _dbContext.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task CreateEntradaAssistenciaDescricaoAsync(int entradaAssistenciaTecnicaId ,string descricao, int entradaAssistenciaStatus)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var entradaAssistenciaDocumento = new EntradaAssistenciaDescricao() {
                        Descricao = descricao,
                        EntradaAssistenciaStatusId = entradaAssistenciaStatus,
                        EntradaAssistenciaTecnicaId = entradaAssistenciaTecnicaId,                        
                        DataGravacao = DateTime.Now                        
                    };

                    _dbContext.EntradaAssistenciaDescricoes.Add(entradaAssistenciaDocumento);
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

        public async Task CreateEntradaAssistenciaAcessorioAsync(int entradaAssistenciaTecnicaId, List<int> entradaAssistenciaAcesorioList)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var acessorioList = _dbContext.Acessorios.Where(x => entradaAssistenciaAcesorioList.Any(p2 => p2 == x.Id));
                    //var result = list.Where(p => !resultList.Any(p2 => p2.Id == p.Id));
                    var entradaAcessorioList = _dbContext.EntradaAssistenciaAcessorios.Where(x => x.EntradaAssistenciaTecnicaId == entradaAssistenciaTecnicaId);

                    if (acessorioList != null)
                    {
                        foreach (var item in entradaAcessorioList)
                        {
                            _dbContext.EntradaAssistenciaAcessorios.Remove(item);                            
                        }

                       await _dbContext.SaveChangesAsync();
                    }

                    foreach (var item in acessorioList)
                    {
                        var entradaAcessorio = new EntradaAssistenciaAcessorio() { AcessorioId = item.Id, EntradaAssistenciaTecnicaId = entradaAssistenciaTecnicaId};
                        _dbContext.EntradaAssistenciaAcessorios.Add(entradaAcessorio);                       
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
    }
}