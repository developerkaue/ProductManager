using ProductManagementSystem1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementSystem1.Interface
{
    public interface IEstoqueService
    {
        Task<IEnumerable<EstoqueDTO>> ObterTodosAsync();
        Task<EstoqueDTO> ObterPorIdAsync(int id);
        Task CriarEstoqueAsync(EstoqueDTO estoqueDto);
        Task AtualizarEstoqueAsync(EstoqueDTO estoqueDto);
        Task DeletarEstoqueAsync(int id);
        Task<IEnumerable<ProdutoDTO>> ObterProdutosAsync();
        Task<IEnumerable<FornecedorDTO>> ObterFornecedoresAsync();
        Task<string> ObterNomeProdutoAsync(int produtoId);
        Task<string> ObterNomeFornecedorAsync(int fornecedorId);
    }
}
