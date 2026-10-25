namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class EntradaAssistenciaDocumento : BaseEntity
    {
        public EntradaAssistenciaTecnica EntradaAssistenciaTecnica { get; set; }
        public int EntradaAssistenciaTecnicaId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
