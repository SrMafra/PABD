namespace GerirAluguel.Models
{
    public class Despesa
    {
        public int DespesaId { get; set; }
        public string? DescricaoDespesa { get; set; }
        public decimal? ValorDespesa { get; set; }

        public ICollection<ImovelDespesa>? ImovelDespesas { get; set; }
    }
}
