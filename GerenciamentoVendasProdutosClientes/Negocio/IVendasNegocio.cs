using GerenciamentoVendasProdutosClientes.Models;

namespace GerenciamentoVendasProdutosClientes.Negocio
{
    public interface IVendasNegocio
    {

        VendasModel ListarPorId(int id);
        List<VendasModel> BuscarTodos();
        VendasModel InserirVenda(VendasModel venda);
        VendasModel EditarVenda(VendasModel venda);

        bool ExcluirVenda(int idVenda);
    }
}
