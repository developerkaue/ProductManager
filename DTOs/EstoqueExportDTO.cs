namespace ProductManagementSystem1.DTOs
{
    public class EstoqueExportDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int FornecedorId { get; set; }
        public string NomeFornecedor { get; set; }
        public int Quantidade { get; set; }
    }
}
