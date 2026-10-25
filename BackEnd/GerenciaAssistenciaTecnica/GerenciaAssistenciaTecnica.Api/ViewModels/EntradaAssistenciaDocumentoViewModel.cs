namespace GerenciaAssistenciaTecnica.Api.ViewModels
{
    public class EntradaAssistenciaDocumentoViewModel
    {
        public int Id { get; set; }
        public int EntradaAssistenciaTecnicaId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
