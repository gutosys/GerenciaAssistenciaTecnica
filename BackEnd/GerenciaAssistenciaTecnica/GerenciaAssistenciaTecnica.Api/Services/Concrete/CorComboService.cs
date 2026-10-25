using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Core.Entities;
using System;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class CorComboService : ICorComboService
    {
        private readonly ICorRepository _corRepository;

        public CorComboService(ICorRepository corRepository)
        {
            _corRepository = corRepository ?? throw new ArgumentNullException(nameof(corRepository));
        }
        public List<Cor> ReadList()
        {
            return _corRepository.ReadList();
        }
    }
}
