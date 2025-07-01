namespace GerirAluguel.Models
{
    public class Inquilino
    {
        public int InquilinoId { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public ICollection<Contrato>? Contratos { get; set; }

    }
}
