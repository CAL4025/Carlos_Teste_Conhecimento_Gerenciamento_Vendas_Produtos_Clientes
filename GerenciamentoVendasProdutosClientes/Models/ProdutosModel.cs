namespace GerenciamentoVendasProdutosClientes.Models
{
    public class ProdutosModel
    {
        public int Id { get; set; }
        public string dscProduto { get; set; }
        public double vlrUnitario { get; set; }
       

        public ProdutosModel()
        {
            dscProduto = string.Empty;

        }
    }
}
