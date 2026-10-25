using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class EtiquetaService : IEtiquetaService
    {
        private readonly IEtiquetaRepository _etiquetaRepository;

        public EtiquetaService(IEtiquetaRepository etiquetaRepository)
        {
            _etiquetaRepository = etiquetaRepository ?? throw new ArgumentNullException(nameof(etiquetaRepository));
        }

        public Task<Etiqueta> CreateAsync(Etiqueta etiqueta)
        {
            return _etiquetaRepository.AddAsync(etiqueta);
        }

        public async Task DeleteAsync(Etiqueta etiqueta)
        {
            await _etiquetaRepository.DeleteAsync(etiqueta);
        }

        public bool IsEtiquetaExistsAsync(int id)
        {
            return _etiquetaRepository.IsEtiquetaExistsAsync(id);
        }

        public async Task<IEnumerable<Etiqueta>> ReadAllAsync()
        {
            return await _etiquetaRepository.ReadAllAsync();
        }

        public async Task<Etiqueta> ReadOneAsync(int id)
        {
            return await _etiquetaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Etiqueta etiqueta)
        {
            await _etiquetaRepository.UpdateAsync(etiqueta);
        }
    }
}
