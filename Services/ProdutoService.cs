using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;
using ProductManagementSystem1.DTOs;


namespace ProductManagementSystem1.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IFornecedorRepository fornecedorRepository)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<bool> CriarProdutoAsync(ProdutoDTO produtoDto)
        {
            var fornecedor = await _fornecedorRepository.ObterPorIdAsync(produtoDto.FornecedorId);
            if (fornecedor == null)
            {
                return false;
            }

            var produto = new Product
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Preco = produtoDto.Preco,
                FornecedorId = produtoDto.FornecedorId,
                DataDeCriacao = produtoDto.DataDeCriacao,
                Fornecedor = fornecedor
            };

            await _produtoRepository.AdicionarAsync(produto);
            return true;
        }

        public async Task<IEnumerable<FornecedorDTO>> ObterFornecedoresAsync()
        {
            var fornecedores = await _fornecedorRepository.ObterTodosAsync();
            return fornecedores.Select(f => new FornecedorDTO { Id = f.Id, Nome = f.Nome }).ToList();
        }
    }

}
