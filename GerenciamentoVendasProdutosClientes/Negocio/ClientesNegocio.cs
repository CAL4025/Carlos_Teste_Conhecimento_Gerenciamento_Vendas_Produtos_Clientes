using GerenciamentoVendasProdutosClientes.Data;
using GerenciamentoVendasProdutosClientes.Models;

namespace GerenciamentoVendasProdutosClientes.Negocio
{
    public class ClientesNegocio : IClientesNegocio
    {

        private readonly BancoContext _bancoContext;

        public ClientesNegocio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClientesModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }
        public List<ClientesModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }


        public ClientesModel InserirCliente(ClientesModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public ClientesModel EditarCliente(ClientesModel cliente)
        {
            ClientesModel clienteDB = ListarPorId(cliente.Id);

            if (clienteDB == null)
            {
                throw new Exception("Não foi possível editar o contato!");
            }
            else
            {
                clienteDB.nmCliente = cliente.nmCliente;
                clienteDB.cidade = cliente.cidade;
                
               
            }
            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();
            return clienteDB;
        }

        public bool ExcluirCliente(int idProduto)
        {
            ClientesModel clienteDB = ListarPorId(idProduto);

            if (clienteDB == null)
            {
                throw new Exception("Erro ao excluir cliente!");
            }
            else
            {
                _bancoContext.Clientes.Remove(clienteDB);
                _bancoContext.SaveChanges();

                return true;
            }

        }


    }
}
