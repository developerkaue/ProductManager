using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem1.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Nome { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        // Propriedade de navegação para os Produtos
        public ICollection<Product> Produtos { get; set; }
    }
}
