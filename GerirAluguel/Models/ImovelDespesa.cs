namespace GerirAluguel.Models
{
    public class ImovelDespesa
    {
        public int ImovelId { get; set; }
        public Imovel? Imovel { get; set; }

        public int? DespesaId { get; set; }
        public Despesa? Despesa { get; set; }
    }
}