using Microsoft.EntityFrameworkCore;
using ProductManagementSystem1.Data;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementSystem1.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.FromSqlRaw("EXEC spGetAllProdutos").ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var produto = await _context.Products.FromSqlRaw("EXEC spGetProdutoById @Id={0}", id).FirstOrDefaultAsync();
            return produto;
        }

        public async Task AddAsync(Product produto)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spAddProduto @Nome={0}, @Descricao={1}, @Preco={2}, @FornecedorId={3}",
                produto.Nome, produto.Descricao, produto.Preco, produto.FornecedorId);
        }

        public async Task UpdateAsync(Product produto)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spUpdateProduto @Id={0}, @Nome={1}, @Descricao={2}, @Preco={3}, @FornecedorId={4}",
                produto.Id, produto.Nome, produto.Descricao, produto.Preco, produto.FornecedorId);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spDeleteProduto @Id={0}", id);
        }
    }
}
