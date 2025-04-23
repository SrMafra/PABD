namespace GerirAluguel.Models
{
    public class ImovelDespesa
    {
        public int IdImovel { get; set; }
        public Imovel? Imovel { get; set; }

        public int? IdDespesa { get; set; }
        public Despesa? Despesa { get; set; }
    }
}