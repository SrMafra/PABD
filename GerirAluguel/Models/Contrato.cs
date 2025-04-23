namespace GerirAluguel.Models
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorMensal { get; set; }
        public int IdInquilino { get; set; }
        public Inquilino? Inquilino { get; set; }
        public int IdImovel { get; set; }
        public Imovel? Imovel { get; set; }
        public ICollection<Receita>? Receitas { get; set; }



    }
}
