namespace GerirAluguel.Models
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorMensal { get; set; }
        public int InquilinoId { get; set; }
        public Inquilino? Inquilino { get; set; }
        public int ImovelId { get; set; }
        public Imoveis? Imovel { get; set; }
        public ICollection<Receita>? Receitas { get; set; }



    }
}
