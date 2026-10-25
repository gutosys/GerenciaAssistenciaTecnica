using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository ?? throw new ArgumentNullException(nameof(estoqueRepository));
        }

        public async Task<Estoque> CreateAsync(Estoque estoque)
        {
            try
            {

                return await _estoqueRepository.AddAsync(estoque);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(Estoque estoque)
        {
            _estoqueRepository.Delete(estoque);
        }

        public bool IsEstoqueExistsAsync(int id)
        {
            return _estoqueRepository.IsEstoqueExistsAsync(id);
        }

        public async Task<IEnumerable<Estoque>> ReadAllAsync()
        {
            return await _estoqueRepository.ReadAllAsync();
        }

        public async Task<Estoque> ReadOneAsync(int id)
        {
            return await _estoqueRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Estoque estoque)
        {
            await _estoqueRepository.UpdateAsync(estoque);
        }
    }
}