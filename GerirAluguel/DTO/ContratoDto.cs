namespace GerirAluguel.Dto
{
    public class ContratoDto
    {
        public int ContratoId { get; set; }
        public int InquilinoId { get; set; }
        public int ImovelId{ get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal ValorMensal { get; set; }
    }
}
