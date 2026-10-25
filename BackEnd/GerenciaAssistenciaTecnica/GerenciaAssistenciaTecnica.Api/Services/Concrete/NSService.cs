using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;

namespace GerenciaAssistenciaTecnica.Api.Services.Concrete
{
    public class NSService : INSService
    {
        private readonly INSRepository _nsRepository;

        public NSService(INSRepository  nsRepository)
        {
            this._nsRepository = nsRepository;
        }

        public bool NSExists(string ns, string Ns)
        {
            return _nsRepository.NSExists(ns, Ns);
        }
    }
}
