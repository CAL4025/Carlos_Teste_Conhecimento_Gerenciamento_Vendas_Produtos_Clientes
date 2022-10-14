namespace GerenciamentoVendasProdutosClientes.Models
{
    public class ClientesModel
    {

        public int Id { get; set; }
        public string nmCliente { get; set; }
        public string cidade { get; set; }


        public ClientesModel()
        {
            nmCliente = string.Empty;
            cidade = string.Empty;

        }
    }
}
