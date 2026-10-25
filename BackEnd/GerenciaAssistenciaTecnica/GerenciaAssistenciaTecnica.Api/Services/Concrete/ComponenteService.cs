using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class ComponenteService : IComponenteService
    {
        private readonly IComponenteRepository _componenteRepository;

        public ComponenteService(IComponenteRepository componenteRepository)
        {
            _componenteRepository = componenteRepository ?? throw new ArgumentNullException(nameof(componenteRepository));
        }

        public async Task<Componente> CreateAsync(Componente componente)
        {
            try
            {
                return await _componenteRepository.AddAsync(componente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(Componente componente)
        {
            _componenteRepository.Delete(componente);
        }

        public bool IsComponenteExistsAsync(int componenteId)
        {
            return _componenteRepository.IsComponenteExistsAsync(componenteId);
        }

        public async Task<IEnumerable<Componente>> ReadAllAsync()
        {
            return await _componenteRepository.ReadAllAsync();
        }

        public async Task<Componente> ReadOneAsync(int id)
        {
            return await _componenteRepository.GetByIdAsync(id);
        }

        public async  Task UpdateAsync(Componente componente)
        {
            await _componenteRepository.UpdateAsync(componente);
        }
    }
}
