namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Cidade : BaseEntity
    {
        public string Descricao { get; set; }        
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
