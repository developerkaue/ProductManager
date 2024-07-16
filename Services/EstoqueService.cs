using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagementSystem1.DTOs;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;
using ProductManagementSystem1.Repository;

namespace ProductManagementSystem1.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorRepository _fornecedorService;
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, IProdutoService produtoService, IFornecedorRepository fornecedorService)
        {
            _estoqueRepository = estoqueRepository;
            _produtoService = produtoService;
            _fornecedorService = fornecedorService;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<EstoqueDTO>> ObterTodosAsync()
        {
            var estoques = await _estoqueRepository.GetAllAsync();

            var estoquesDTO = new List<EstoqueDTO>();

            foreach (var estoque in estoques)
            {
                var produtoNome = await _produtoService.ObterNomeProdutoAsync(estoque.ProdutoId);
                var fornecedorNome = await _fornecedorService.ObterNomeFornecedorAsync(estoque.FornecedorId);

                estoquesDTO.Add(new EstoqueDTO
                {
                    Id = estoque.Id,
                    ProdutoId = estoque.ProdutoId,
                    FornecedorId = estoque.FornecedorId,
                    Quantidade = estoque.Quantidade
                });
            }

            return estoquesDTO;
        }


        public async Task<EstoqueDTO> ObterPorIdAsync(int id)
        {
            var estoque = await _estoqueRepository.GetByIdAsync(id);
            if (estoque == null)
                return null;

            var produtoNome = await _produtoService.ObterNomeProdutoAsync(estoque.ProdutoId);
            var fornecedorNome = await _fornecedorService.ObterNomeFornecedorAsync(estoque.FornecedorId);

            return new EstoqueDTO
            {
                Id = estoque.Id,
                ProdutoId = estoque.ProdutoId,
                FornecedorId = estoque.FornecedorId,
                Quantidade = estoque.Quantidade
            };
        }

        public async Task AtualizarEstoqueAsync(EstoqueDTO estoqueDto)
        {
            var estoque = await _estoqueRepository.GetByIdAsync(estoqueDto.Id);
            if (estoque == null)
            {
                throw new Exception("Estoque não encontrado.");
            }

            var produto = await _produtoRepository.GetByIdAsync(estoque.ProdutoId);
            if (produto == null)
            {
                throw new Exception("Produto associado ao estoque não encontrado.");
            }

            // Atualiza a quantidade no estoque
            estoque.Quantidade = estoqueDto.Quantidade;

            // Atualiza a quantidade no produto associado
            produto.Quantidade = estoqueDto.Quantidade;

            // Salva as alterações no estoque e no produto
            await _estoqueRepository.AtualizarAsync(estoque);
            await _produtoRepository.AtualizarAsync(produto);

            // Pode-se adicionar aqui lógica adicional, como logs ou atualizações em outros sistemas

            return;
        }

        public async Task CriarEstoqueAsync(EstoqueDTO estoqueDto)
        {
            var estoque = new Estoque
            {
                ProdutoId = estoqueDto.ProdutoId,
                FornecedorId = estoqueDto.FornecedorId,
                Quantidade = estoqueDto.Quantidade
            };

            await _estoqueRepository.AddAsync(estoque);
        }



        public async Task DeletarEstoqueAsync(int id)
        {
            await _estoqueRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProdutosAsync()
        {
            return await _produtoService.GetAllAsync();
        }

        public async Task<IEnumerable<FornecedorDTO>> ObterFornecedoresAsync()
        {
            var fornecedores = await _fornecedorService.ObterTodosAsync();
            return fornecedores.Select(f => new FornecedorDTO
            {
                Id = f.Id,
                Nome = f.Nome,
            });
        }

        public async Task<string> ObterNomeProdutoAsync(int produtoId)
        {
            var produto = await _produtoService.GetByIdAsync(produtoId);
            return produto?.Nome;
        }


        public async Task<string> ObterNomeFornecedorAsync(int fornecedorId)
        {
            var fornecedor = await _fornecedorService.ObterPorIdAsync(fornecedorId);
            return fornecedor?.Nome;
        }
    }
}
