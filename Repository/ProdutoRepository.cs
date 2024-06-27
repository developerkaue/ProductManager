using ProductManagementSystem1.Data;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Product produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }
    }

}
