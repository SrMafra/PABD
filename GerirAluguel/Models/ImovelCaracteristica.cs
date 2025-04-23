namespace GerirAluguel.Models
{
    public class ImovelCaracteristica
    {
        public int IdImovel { get; set; }
        public Imovel? Imovel { get; set; }

        public int? IdCaracteristica { get; set; }
        public Caracteristica? Caracteristica { get; set; }
    }
}