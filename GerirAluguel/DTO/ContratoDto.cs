namespace GerirAluguel.Dto
{
    public class ContratoDto
    {
        public int IdInquilino { get; set; }
        public int IdImovel{ get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorMensal { get; set; }
    }
}
