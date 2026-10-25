using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class AcessorioAssistenciaService : IAcessorioAssistenciaService
    {   

        private readonly IAcessorioAssistenciaRepository _acessorioAssistenciaRepository;

        public AcessorioAssistenciaService(IAcessorioAssistenciaRepository acessorioAssistenciaRepository)
        {
            this._acessorioAssistenciaRepository = acessorioAssistenciaRepository;
        }

        public async Task CreateAsync(int entradaAssistenciaId, ICollection<AcessorioMaquinaAssistencia> acessorioList)
        {
            try
            {
                await _acessorioAssistenciaRepository.AddAsync(entradaAssistenciaId, acessorioList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
