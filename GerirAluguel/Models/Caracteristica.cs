namespace GerirAluguel.Models
{
    public class Caracteristica
    {
        public int CaracteristicaId { get; set; }
        public string? Nome { get; set; }
        public ICollection<ImovelCaracteristica>? ImovelCaracteristicas { get; set; }

    }
}