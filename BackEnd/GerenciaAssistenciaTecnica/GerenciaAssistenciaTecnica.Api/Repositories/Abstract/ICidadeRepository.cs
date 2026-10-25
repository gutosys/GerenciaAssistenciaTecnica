using GerenciaAssistenciaTecnica.Core.Entities;
using GerenciaAssistenciaTecnica.Core.Interfaces;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Api.Repositories
{
    public interface ICidadeRepository : IAsyncRepository<Cidade>
    {
        bool IsCidadeExistsAsync(int id);

        List<Cidade> ReadListByEstado(int estadoId);
    }
}
