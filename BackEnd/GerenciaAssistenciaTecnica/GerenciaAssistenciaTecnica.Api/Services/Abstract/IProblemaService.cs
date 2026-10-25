using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface IProblemaService
    {
        Task<Problema> CreateAsync(Problema problema);

        Task DeleteAsync(Problema problema);

        bool IsProblemaExistsAsync(int problemaId);

        Task<IEnumerable<Problema>> ReadAllAsync();

        Task<Problema> ReadOneAsync(int id);

        Task UpdateAsync(Problema problema);
    }
}
