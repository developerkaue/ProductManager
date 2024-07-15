namespace ProductManagementSystem1.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int FornecedorId { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public int Quantidade { get; set; }
    }
}
