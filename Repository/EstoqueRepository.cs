using ProductManagementSystem1.Data;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


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
            return await _context.Estoques
                .Include(e => e.Produto)
                .Include(e => e.Fornecedor)
                .ToListAsync();
        }

        public async Task<Estoque> GetByIdAsync(int id)
        {
            return await _context.Estoques
                .Include(e => e.Produto)
                .Include(e => e.Fornecedor)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Estoque estoque)
        {

            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Estoque estoque)
        {
            _context.Estoques.Update(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Estoque estoque)
        {
            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque != null)
            {
                _context.Estoques.Remove(estoque);
                await _context.SaveChangesAsync();
            }
        }
    }

}
