namespace GerenciaAssistenciaTecnica.Core.Entities
{
    public class Etiqueta : BaseEntity
    {
        public string Descricao { get; set; }

        public int CorId { get; set; }

        public Cor Cor{ get; set; }
    }

    public class Cor : BaseEntity
    {
        public string Descricao { get; set; }
        public string ColorHex { get; set; }
    }

    public class EtiquetaViewModel
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }

        public int CorId { get; set; }
        public string ColorHex { get; set; }

        public string CorDes { get; set; }
    }
}
