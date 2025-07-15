namespace GerirAluguel.Models
{
    public class Receita
    {
        public int ReceitaId { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public string? Situacao { get; set; }
        public int? ContratoId { get; set; }
        public Contrato? Contrato { get; set; }
    }
}
