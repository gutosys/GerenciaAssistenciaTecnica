using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Services.Abstract
{
    public interface INumeroSerieService
    {
        bool NumeroSerieExists(string numeroSerie, string numeroProtocoloTroca);
    }
}
