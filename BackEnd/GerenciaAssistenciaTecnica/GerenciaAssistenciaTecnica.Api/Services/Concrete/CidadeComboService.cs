using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Core.Entities;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public class CidadeComboService : ICidadeComboService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeComboService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
        }
        public List<Cidade> ReadListByEstado(int id)
        {
            return _cidadeRepository.ReadListByEstado(id);
        }
    }
}
