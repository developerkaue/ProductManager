using ProductManagementSystem1.DTOs;
namespace ProductManagementSystem1.Interface
{
    public interface IProdutoService
    {
        Task<bool> CriarProdutoAsync(ProdutoDTO produtoDto);
        Task<IEnumerable<FornecedorDTO>> ObterFornecedoresAsync();

        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO> GetByIdAsync(int id);

        Task<string> ObterNomeProdutoAsync(int produtoId);
    }
}
