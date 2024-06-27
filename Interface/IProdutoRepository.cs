using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Interface
{
    public interface IProdutoRepository
    {
        Task AdicionarAsync(Product produto);
    }
}
