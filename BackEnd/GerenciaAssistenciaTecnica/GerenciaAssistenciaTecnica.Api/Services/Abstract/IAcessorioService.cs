using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Abstract
{
    public interface IAcessorioService
    {
        Task<Acessorio> CreateAsync(Acessorio acessorio);

        Task DeleteAsync(Acessorio acessorio);

        bool IsAcessorioExistsAsync(int acessorioId);

        Task<IEnumerable<Acessorio>> ReadAllAsync();

        Task<Acessorio> ReadOneAsync(int id);

        Task UpdateAsync(Acessorio acessorio);
    }
}
