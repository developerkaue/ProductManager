using Microsoft.EntityFrameworkCore;
using ProductManagementSystem1.Data;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProductManagementSystem1.Repository
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ApplicationDbContext _context;

        public EstoqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estoque>> GetAllAsync()
        {
            return await _context.Estoques.FromSqlRaw("EXEC spGetAllEstoques").ToListAsync();
        }

        public async Task<Estoque> GetByIdAsync(int id)
        {
            var estoque = await _context.Estoques.FromSqlRaw("EXEC spGetEstoqueById @Id={0}", id).FirstOrDefaultAsync();
            return estoque;
        }

        public async Task AddAsync(Estoque estoque)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spAddEstoque @ProdutoId={0}, @FornecedorId={1}, @Quantidade={2}",
                estoque.ProdutoId, estoque.FornecedorId, estoque.Quantidade);
        }

        public async Task UpdateAsync(Estoque estoque)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spUpdateEstoque @Id={0}, @ProdutoId={1}, @FornecedorId={2}, @Quantidade={3}",
                estoque.Id, estoque.ProdutoId, estoque.FornecedorId, estoque.Quantidade);
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spDeleteEstoque @Id={0}", id);
        }

        public async Task AtualizarAsync(Estoque estoque)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC spUpdateEstoque @Id={0}, @ProdutoId={1}, @FornecedorId={2}, @Quantidade={3}",
                estoque.Id, estoque.ProdutoId, estoque.FornecedorId, estoque.Quantidade);
        }
    }
}
