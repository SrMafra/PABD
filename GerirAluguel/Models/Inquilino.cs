namespace GerirAluguel.Models
{
    public class Inquilino
    {
        public int IdInquilino { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public ICollection<Contrato>? Contratos { get; set; }

    }
}
