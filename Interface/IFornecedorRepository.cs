using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Interface
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> ObterPorIdAsync(int id);
        Task<IEnumerable<Fornecedor>> ObterTodosAsync();
    }
}
