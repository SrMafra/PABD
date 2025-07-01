namespace GerirAluguel.Models
{
    public class Imoveis
    {
        public int ImovelId { get; set; }
        public string? DescricaoImovel { get; set; }
        public string? Endereco { get; set; }
        public decimal ValorAluguel { get; set; }
        public string? Status { get; set; } = "DISPONÍVEL";

        public ICollection<Contrato>? Contrato { get; set; }
        public ICollection<ImovelDespesa>?  ImovelDespesas { get; set; }
        public ICollection <ImovelCaracteristica>? ImovelCaracteristicas { get; set; }
    }
}