using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagementSystem1.DTOs;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;

namespace ProductManagementSystem1.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEstoqueRepository _estoqueRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IFornecedorRepository fornecedorRepository, IEstoqueRepository estoqueRepository)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task<string> ObterNomeProdutoAsync(int produtoId)
        {
            var produto = await _produtoRepository.GetByIdAsync(produtoId);
            return produto?.Nome;
        }

        public async Task<ProdutoDTO> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
                return null;

            return new ProdutoDTO { Id = produto.Id, Nome = produto.Nome };
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Select(p => new ProdutoDTO { Id = p.Id, Nome = p.Nome });
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
                DataDeCriacao = DateTime.UtcNow, // Data de criação definida como UTC agora
                Quantidade = produtoDto.Quantidade,
                Fornecedor = fornecedor
            };

            await _produtoRepository.AdicionarAsync(produto);

            // Após salvar o produto, criar automaticamente um registro de estoque
            var estoque = new Estoque
            {
                ProdutoId = produto.Id,
                FornecedorId = produto.FornecedorId,
                Quantidade = produto.Quantidade
            };

            await _estoqueRepository.AddAsync(estoque);

            return true;
        }

        public async Task<IEnumerable<FornecedorDTO>> ObterFornecedoresAsync()
        {
            var fornecedores = await _fornecedorRepository.ObterTodosAsync();
            return fornecedores.Select(f => new FornecedorDTO { Id = f.Id, Nome = f.Nome }).ToList();
        }
    }
}
