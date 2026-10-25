using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public class ClienteAssociadoRepository : EfRepository<ClienteAssociado>, IClienteAssociadoRepository
    {
        public ClienteAssociadoRepository(GerenciaAssistenciaTecnicaContext dbContext) : base(dbContext)
        {
        }

        public bool IsClienteAssociadoExistsAsync(int id)
        {
            return _dbContext.ClienteAssociados.Any(t => t.Id == id);
        }

        public async Task<IEnumerable<ClienteAssociado>> ReadAllAsync()
        {
            return _dbContext.ClienteAssociados.Include(x => x.PessoaJuridica);
        }

        public List<ClienteAssociado> ReadListByPessoaJuridica(int pessoaJuridicaId)
        {
            throw new NotImplementedException();

            //return _dbContext.Cidades.Where(x => x.EstadoId == estadoId).ToList();
        }
    }
}
