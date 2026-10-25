using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository ?? throw new ArgumentNullException(nameof(funcionarioRepository));
        }

        public async Task<Funcionario> CreateAsync(Funcionario funcionario)
        {
            try
            {

                return await _funcionarioRepository.AddAsync(funcionario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteAsync(Funcionario funcionario)
        {
           await _funcionarioRepository.DeleteAsync(funcionario);
        }

        public bool IsFuncionarioExistsAsync(int funcionarioId)
        {
            return _funcionarioRepository.IsFuncionarioExistsAsync(funcionarioId);
        }

        public async Task<IEnumerable<Funcionario>> ReadAllAsync()
        {
            return await _funcionarioRepository.ReadAllAsync();
        }

        public async Task<Funcionario> ReadOneAsync(int id)
        {
            return await _funcionarioRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Funcionario funcionario)
        {
            await _funcionarioRepository.UpdateAsync(funcionario);
        }
    }
}
