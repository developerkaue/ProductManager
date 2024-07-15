using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ProductManagementSystem1.DTOs;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Services;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;



namespace ProductManagementSystem1.Controllers
{
    [Authorize]
    public class EstoquesController : Controller
    {
        private readonly IEstoqueService _estoqueService;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorRepository  _fornecedorService;

        public EstoquesController(IEstoqueService estoqueService, IProdutoService produtoService, IFornecedorRepository fornecedorService)
        {
            _estoqueService = estoqueService;
            _produtoService = produtoService;
            _fornecedorService = fornecedorService;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueService.ObterTodosAsync();

            var estoqueList = new List<EstoqueListDTO>();

            foreach (var estoque in estoques)
            {
                var produto = await _produtoService.GetByIdAsync(estoque.ProdutoId);
                var fornecedor = await _fornecedorService.ObterPorIdAsync(estoque.FornecedorId);

                var estoqueItem = new EstoqueListDTO
                {
                    Id = estoque.Id,
                    ProdutoId = estoque.ProdutoId,
                    NomeProduto = produto?.Nome,
                    FornecedorId = estoque.FornecedorId,
                    NomeFornecedor = fornecedor?.Nome,
                    Quantidade = estoque.Quantidade
                };

                estoqueList.Add(estoqueItem);
            }

            return View(estoqueList);
        }


        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.ObterPorIdAsync(id.Value);
            if (estoque == null)
            {
                return NotFound();
            }

            ViewData["ProdutoNome"] = await _produtoService.ObterNomeProdutoAsync(estoque.ProdutoId);
            ViewData["FornecedorNome"] = await _fornecedorService.ObterNomeFornecedorAsync(estoque.FornecedorId);

            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var estoque = await _estoqueService.ObterPorIdAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }

            // Carrega o nome do produto e do fornecedor para exibição na view
            ViewData["ProdutoNome"] = await _produtoService.ObterNomeProdutoAsync(estoque.ProdutoId);
            ViewData["FornecedorNome"] = await _fornecedorService.ObterNomeFornecedorAsync(estoque.FornecedorId);

            return View(estoque);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstoqueDTO estoqueDto)
        {
            if (id != estoqueDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Crie um objeto EstoqueDTO simplificado apenas com Id e Quantidade
                    var estoqueAtualizado = new EstoqueDTO
                    {
                        Id = estoqueDto.Id,
                        Quantidade = estoqueDto.Quantidade
                    };

                    await _estoqueService.AtualizarEstoqueAsync(estoqueAtualizado);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao atualizar o estoque: " + ex.Message);
                }
            }

            // Recarregue os nomes de produto e fornecedor para exibição na view, se necessário
            ViewData["ProdutoNome"] = await _produtoService.ObterNomeProdutoAsync(estoqueDto.ProdutoId);
            ViewData["FornecedorNome"] = await _fornecedorService.ObterNomeFornecedorAsync(estoqueDto.FornecedorId);

            return View(estoqueDto);
        }




        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.ObterPorIdAsync(id.Value);
            if (estoque == null)
            {
                return NotFound();
            }

            ViewData["ProdutoNome"] = await _produtoService.ObterNomeProdutoAsync(estoque.ProdutoId);
            ViewData["FornecedorNome"] = await _fornecedorService.ObterNomeFornecedorAsync(estoque.FornecedorId);

            return View(estoque);
        }


        // POST: Estoques/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _estoqueService.DeletarEstoqueAsync(id);
            return RedirectToAction(nameof(Index));
        }

         [HttpGet]
        public async Task<IActionResult> ExportToCsv()
        {
            var estoques = await _estoqueService.ObterTodosAsync();

            var exportData = new List<EstoqueExportDTO>();

            foreach (var estoque in estoques)
            {
                var produto = await _produtoService.GetByIdAsync(estoque.ProdutoId);
                var fornecedor = await _fornecedorService.ObterPorIdAsync(estoque.FornecedorId);

                var exportItem = new EstoqueExportDTO
                {
                    Id = estoque.Id,
                    ProdutoId = estoque.ProdutoId,
                    NomeProduto = produto?.Nome, // Assumindo que Nome está presente em Produto
                    FornecedorId = estoque.FornecedorId,
                    NomeFornecedor = fornecedor?.Nome, // Assumindo que Nome está presente em Fornecedor
                    Quantidade = estoque.Quantidade
                };

                exportData.Add(exportItem);
            }

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(exportData);
                writer.Flush();
                var result = memoryStream.ToArray();

                return File(result, "text/csv", "estoques.csv");
            }
        }


    }
}
