namespace GerirAluguel.DTO
{
    public class ImovelDto
    {
        public int ImovelId { get; set; }
        public string? DescricaoImovel { get; set; }
        public string? Endereco { get; set; }
        public decimal ValorAluguel { get; set; }
        public string? Status { get; set; }

    }
}
