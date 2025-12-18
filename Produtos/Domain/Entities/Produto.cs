namespace ProdutoAPI.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}
