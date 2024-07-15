using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem1.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Product Produto { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int Quantidade { get; set; }
    }
}
