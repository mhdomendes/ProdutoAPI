namespace ProdutoAPI.DTOs
{
    public class UpdateProdutoDto
    {
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}
