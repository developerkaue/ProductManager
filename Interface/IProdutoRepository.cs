using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Interface
{
    public interface IProdutoRepository
    {
        Task AdicionarAsync(Product produto);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AtualizarAsync(Product produto);
        Task<Product> GetByIdAsync(int id); // Correção: Adicionando o parâmetro 'int id'
    }
}
