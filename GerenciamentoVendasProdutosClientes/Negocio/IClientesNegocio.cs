using GerenciamentoVendasProdutosClientes.Models;

namespace GerenciamentoVendasProdutosClientes.Negocio
{
    public interface IClientesNegocio
    {

        ClientesModel ListarPorId(int id);
        List<ClientesModel> BuscarTodos();
        ClientesModel InserirCliente(ClientesModel cliente);
        ClientesModel EditarCliente(ClientesModel cliente);

        bool ExcluirCliente(int idCliente);

    }
}
