namespace GerenciaAssistenciaTecnica.Api.Repositories.Abstract
{
    public interface INumeroSerieRepository
    {
        bool NumeroSerieExists(string numeroSerie, string numeroProtocoloTroca);
    }
}
