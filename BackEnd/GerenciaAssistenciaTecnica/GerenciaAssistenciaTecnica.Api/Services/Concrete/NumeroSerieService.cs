using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class NumeroSerieService : INumeroSerieService
    {
        private readonly INumeroSerieRepository _numeroSerieRepository;

        public NumeroSerieService(INumeroSerieRepository numeroSerieRepository)
        {
            this._numeroSerieRepository = numeroSerieRepository;
        }

         public bool NumeroSerieExists(string numeroSerie, string numeroProtocoloTroca)
        {
            return _numeroSerieRepository.NumeroSerieExists(numeroSerie, numeroProtocoloTroca);
        }
    }
}
