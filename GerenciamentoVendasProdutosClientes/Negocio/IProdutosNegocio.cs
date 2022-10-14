using GerenciamentoVendasProdutosClientes.Models;

namespace GerenciamentoVendasProdutosClientes.Negocio
{
    public interface IProdutosNegocio
    {

        ProdutosModel ListarPorId(int id);
        List<ProdutosModel> BuscarTodos();
        ProdutosModel InserirVenda(ProdutosModel cliente);
        ProdutosModel EditarVenda(ProdutosModel cliente);

        bool ExcluirProduto(int idProduto);

    }
}
