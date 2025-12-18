using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Domain.Entities;

namespace ProdutoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos => Set<Produto>();
    }
}
