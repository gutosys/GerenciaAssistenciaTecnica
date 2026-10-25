using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
        }

        public Task<Categoria> CreateAsync(Categoria categoria)
        {
            return _categoriaRepository.AddAsync(categoria);
        }

        public async Task DeleteAsync(Categoria categoria)
        {
            await _categoriaRepository.DeleteAsync(categoria);
        }

        public bool IsCategoriaExistsAsync(int id)
        {
            return _categoriaRepository.IsCategoriaExistsAsync(id);
        }

        public async Task<IEnumerable<Categoria>> ReadAllAsync()
        {
            return await _categoriaRepository.ListAllAsync();
        }

        public async Task<Categoria> ReadOneAsync(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            await _categoriaRepository.UpdateAsync(categoria);
        }
    }
}
