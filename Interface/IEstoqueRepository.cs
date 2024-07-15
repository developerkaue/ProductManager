using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Interface
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<Estoque>> GetAllAsync();
        Task<Estoque> GetByIdAsync(int id);
        Task AddAsync(Estoque estoque);
        Task UpdateAsync(Estoque estoque);
        Task DeleteAsync(int id);
        Task AtualizarAsync(Estoque estoque);
    }
}
