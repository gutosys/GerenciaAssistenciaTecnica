using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Api.Services
{
    public interface ICidadeComboService
    {
        List<Cidade> ReadListByEstado(int id);        
    }
}
