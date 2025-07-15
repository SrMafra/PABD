namespace GerirAluguel.DTO
{
    public class ReceitaDto
    {
        public DateTime? DataPagamento { get; set; }
        public decimal ValorPagamento { get; set; }
        public string? Situacao { get; set; }
        public int ContratoId { get; set; }
    }
}
