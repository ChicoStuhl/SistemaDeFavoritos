namespace SistemaDeFavoritos.Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Classificacao { get; set; }
        public string? ImageUrl { get; set; }
        public int? Status { get; set; }
    }
}
