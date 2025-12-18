namespace ProdutoAPI.DTOs
{
    public class CreateProdutoDto
    {
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}
