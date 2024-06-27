using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem1.Data;
using ProductManagementSystem1.Interface;
using ProductManagementSystem1.Models;
using ProductManagementSystem1.DTOs;

namespace ProductManagementSystem1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProdutoService _produtoService;

        // Construtor combinado
        public ProductsController(ApplicationDbContext context, IProdutoService produtoService)
        {
            _context = context;
            _produtoService = produtoService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.Fornecedor).ToListAsync();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome");
            Console.WriteLine(ViewData["FornecedorId"]);
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Fornecedores"] = new SelectList(await _produtoService.ObterFornecedoresAsync(), "Id", "Nome");
                return View(produtoDto);
            }

            var sucesso = await _produtoService.CriarProdutoAsync(produtoDto);
            if (sucesso)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Fornecedor não encontrado.");
            ViewData["Fornecedores"] = new SelectList(await _produtoService.ObterFornecedoresAsync(), "Id", "Nome");
            return View(produtoDto);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Carrega o dropdown de fornecedores com todas as opções
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "Id", "Nome", product.FornecedorId);

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,FornecedorId,DataDeCriacao")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            // Atualizar o fornecedor associado ao produto
            product.Fornecedor = await _context.Fornecedores.FindAsync(product.FornecedorId);

            _context.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
