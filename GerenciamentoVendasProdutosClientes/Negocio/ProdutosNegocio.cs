using GerenciamentoVendasProdutosClientes.Data;
using GerenciamentoVendasProdutosClientes.Models;

namespace GerenciamentoVendasProdutosClientes.Negocio
{
    public class ProdutosNegocio : IProdutosNegocio
    {
        private readonly BancoContext _bancoContext;

        public ProdutosNegocio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutosModel ListarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<ProdutosModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutosModel InserirVenda(ProdutosModel produto)
        {

            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public ProdutosModel EditarVenda(ProdutosModel produto)
        {

            ProdutosModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null)
            {
                throw new Exception("Não foi possível editar o contato!");
            }
            else
            {
                produtoDB.dscProduto = produto.dscProduto;
                produtoDB.vlrUnitario = produto.vlrUnitario;
              
            }
            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();
            return produtoDB;


        }

        public bool ExcluirProduto(int idProduto)
        {
            ProdutosModel produtoDB = ListarPorId(idProduto);

            if (produtoDB == null)
            {
                throw new Exception("Erro ao excluir produto!");
            }
            else
            {
                _bancoContext.Produtos.Remove(produtoDB);
                _bancoContext.SaveChanges();

                return true;
            }

        }
    }
}
