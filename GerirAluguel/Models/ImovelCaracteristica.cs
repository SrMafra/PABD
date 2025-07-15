namespace GerirAluguel.Models
{
    public class ImovelCaracteristica
    {
        public int ImovelId { get; set; }
        public Imovel? Imovel { get; set; }

        public int? CaracteristicaId { get; set; }
        public Caracteristica? Caracteristica { get; set; }
    }
}