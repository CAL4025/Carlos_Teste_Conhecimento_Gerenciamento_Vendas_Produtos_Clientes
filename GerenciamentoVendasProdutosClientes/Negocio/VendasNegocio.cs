using GerenciamentoVendasProdutosClientes.Data;
using GerenciamentoVendasProdutosClientes.Models;


namespace GerenciamentoVendasProdutosClientes.Negocio
{
    public class VendasNegocio : IVendasNegocio
    {

        private readonly BancoContext _bancoContext;

        public VendasNegocio(BancoContext bancoContext)
        {
             _bancoContext = bancoContext;
        }

        public VendasModel ListarPorId(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return _bancoContext.Vendas.FirstOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public List<VendasModel> BuscarTodos()
        {
           return  _bancoContext.Vendas.ToList();
        }

        //public List<VendasModel> PesquisarVenda()
        //{
        //    return _bancoContext.Vendas.ToList();
        //}

        public VendasModel InserirVenda(VendasModel venda)
        {
           
            _bancoContext.Vendas.Add(venda); 
            _bancoContext.SaveChanges();
            return venda;
        }

        public VendasModel EditarVenda(VendasModel venda)
        {
            
            VendasModel vendaDB = ListarPorId(venda.Id);

            if (vendaDB == null)
            {
                throw new Exception("Erro ao editar venda!");
            }
            else
            {
                vendaDB.idCliente = venda.idCliente;
                vendaDB.idProduto = venda.idProduto;
                vendaDB.qtdVenda = venda.qtdVenda;
                vendaDB.vlrUnitarioVenda = venda.vlrUnitarioVenda;
                vendaDB.vlrTotalVenda = venda.vlrTotalVenda;
                vendaDB.dthVenda = venda.dthVenda;
            }

                _bancoContext.Vendas.Update(vendaDB);
                _bancoContext.SaveChanges();
                return vendaDB;
            
            
        }

        public bool ExcluirVenda(int idVenda)
        {
            VendasModel vendaDB = ListarPorId(idVenda);

            if (vendaDB == null) 
            {
                throw new Exception("Erro ao excluir venda!");
            }
            else
            {
                _bancoContext.Vendas.Remove(vendaDB);
                _bancoContext.SaveChanges();
               
                return true;
            }
            
        }
    }
}
