namespace GerirAluguel.Models
{
    public class ImovelCaracteristica
    {
        public int ImovelId { get; set; }
        public Imoveis? Imoveis { get; set; }

        public int? CaracteristicaId { get; set; }
        public Caracteristica? Caracteristica { get; set; }
    }
}