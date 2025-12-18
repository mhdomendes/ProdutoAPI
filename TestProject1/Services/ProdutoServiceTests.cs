using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Data;
using ProdutoAPI.DTOs;
using ProdutoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoAPI.Tests.Services;

    public class ProdutoServiceTests
    {
        private ProdutoService CriarServiceComBancoEmMemoria()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            return new ProdutoService(context);
        }

        [Fact]
        public async Task CriarProduto_ComDadosValidos_DeveCriarComSucesso()
        {
            
            var service = CriarServiceComBancoEmMemoria();

            var dto = new CreateProdutoDto
            {
                Nome = "Produto Teste",
                Preco = 100,
                QuantidadeEmEstoque = 10
            };

            
            var resultado = await service.CriarAsync(dto);
            
            Assert.NotNull(resultado);
            Assert.Equal("Produto Teste", resultado.Nome);
            Assert.Equal(100, resultado.Preco);
        }

        [Fact]
        public async Task CriarProduto_ComPrecoNegativo_DeveLancarExcecao()
        {
            
            var service = CriarServiceComBancoEmMemoria();

            var dto = new CreateProdutoDto
            {
                Nome = "Produto Inválido",
                Preco = -10,
                QuantidadeEmEstoque = 5
            };

            
            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.CriarAsync(dto)
            );
        }

        [Fact]
        public async Task AtualizarProduto_Existente_DeveAtualizarComSucesso()
        {
            
            var service = CriarServiceComBancoEmMemoria();

            var criado = await service.CriarAsync(new CreateProdutoDto
            {
                Nome = "Produto Original",
                Preco = 50,
                QuantidadeEmEstoque = 5
            });

            var updateDto = new UpdateProdutoDto
            {
                Nome = "Produto Atualizado",
                Preco = 80,
                QuantidadeEmEstoque = 10
            };

            
            await service.AtualizarAsync(criado.Id, updateDto);

            var atualizado = await service.ObterPorIdAsync(criado.Id);

            
            Assert.Equal("Produto Atualizado", atualizado.Nome);
            Assert.Equal(80, atualizado.Preco);
        }

        [Fact]
        public async Task ExcluirProduto_Existente_DeveRemoverComSucesso()
        {
            
            var service = CriarServiceComBancoEmMemoria();

            var produto = await service.CriarAsync(new CreateProdutoDto
            {
                Nome = "Produto para excluir",
                Preco = 30,
                QuantidadeEmEstoque = 3
            });

            
            await service.ExcluirAsync(produto.Id);

            
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.ObterPorIdAsync(produto.Id)
            );
        }

        [Fact]
        public async Task ObterProduto_Inexistente_DeveLancarExcecao()
        {
            
            var service = CriarServiceComBancoEmMemoria();

            
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.ObterPorIdAsync(Guid.NewGuid())
            );
        }
    }

