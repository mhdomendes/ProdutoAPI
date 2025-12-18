using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.Domain.Entities;
using ProdutoAPI.DTOs;

namespace ProdutoAPI.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoResponseDto> CriarAsync(CreateProdutoDto dto)
        {
            if (dto.Preco < 0)
                throw new ArgumentException("Preço não pode ser negativo");

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                QuantidadeEmEstoque = dto.QuantidadeEmEstoque
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return MapToResponse(produto);
        }

        public async Task<List<ProdutoResponseDto>> ListarAsync()
        {
            return await _context.Produtos
                .Select(p => MapToResponse(p))
                .ToListAsync();
        }

        public async Task<ProdutoResponseDto> ObterPorIdAsync(Guid id)
        {
            var produto =  await _context.Produtos.FindAsync(id);

            if(produto == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            return MapToResponse(produto);
        }

        public async Task AtualizarAsync(Guid id, UpdateProdutoDto dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if(produto == null)
                throw new KeyNotFoundException("Produto não encontrado.");
            
            if(dto.Preco < 0)
                throw new ArgumentException("O preço não pode ser negativo.");

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Preco = dto.Preco;
            produto.QuantidadeEmEstoque = dto.QuantidadeEmEstoque;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                throw new KeyNotFoundException("Produto não encontrado");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        private static ProdutoResponseDto MapToResponse(Produto produto)
        {
            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque
            };
        }
    }
}
