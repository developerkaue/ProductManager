using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required]
        public int FornecedorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDeCriacao { get; set; }

        // Propriedade de navegação para o Fornecedor
        public Fornecedor Fornecedor { get; set; }

        public int Quantidade { get; set; }
    }
}
