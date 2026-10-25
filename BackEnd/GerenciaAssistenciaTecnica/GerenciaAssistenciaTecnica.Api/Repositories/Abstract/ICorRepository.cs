using GerenciaAssistenciaTecnica.Core.Entities;
using System.Collections.Generic;

namespace GerenciaAssistenciaTecnica.Api.Repositories.Abstract
{
    public interface ICorRepository
    {
        List<Cor> ReadList();
    }
}
