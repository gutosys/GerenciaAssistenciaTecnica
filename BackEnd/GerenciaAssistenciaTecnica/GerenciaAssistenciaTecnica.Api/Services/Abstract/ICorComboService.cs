using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Api.Services.Abstract
{
    public interface ICorComboService
    {
        List<Cor> ReadList();
    }
}
