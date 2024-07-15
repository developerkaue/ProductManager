using Microsoft.EntityFrameworkCore;
using ProductManagementSystem1.Data;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> ObterNomeFornecedorAsync(int fornecedorId)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(fornecedorId);
            return fornecedor?.Nome;
        }
        public async Task<Fornecedor> ObterPorIdAsync(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }
    }

}
