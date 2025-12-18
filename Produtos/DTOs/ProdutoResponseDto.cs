namespace ProdutoAPI.DTOs
{
    public class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}
