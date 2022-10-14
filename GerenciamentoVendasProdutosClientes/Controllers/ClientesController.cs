using GerenciamentoVendasProdutosClientes.Models;
using GerenciamentoVendasProdutosClientes.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoVendasProdutosClientes.Controllers
{
    public class ClientesController : Controller
    {

        private readonly IClientesNegocio _clienteNegocio;

        public ClientesController(IClientesNegocio clienteNegocio)
        {
            _clienteNegocio = clienteNegocio;
        }
        public ActionResult Index(List<ClientesModel> clientes)
        {
          
            clientes = _clienteNegocio.BuscarTodos();

            return View(clientes);
        }  
        
        public ActionResult InserirCliente()
        {
            return View();
        }  
        
        public ActionResult EditarCliente(int id)
        {
            ClientesModel cliente = _clienteNegocio.ListarPorId(id);
            return View(cliente);
        }  
        
        public ActionResult ExcluirCliente(int id)
        {
            
            if (_clienteNegocio.ExcluirCliente(id))
            {
                TempData["Mensagem"] = "1";
            }
            else
            {
                TempData["Mensagem"] = "2";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PesquisarCliente(string nome)
        {
            List<ClientesModel> clientePesquisa = new List<ClientesModel>();
            ClientesModel objCliente = new ClientesModel();



            List<ClientesModel> clientes = _clienteNegocio.BuscarTodos();

            var pesquisa = clientes.Where(cli => cli.nmCliente == nome).ToList();

            foreach (var cliente in pesquisa)
            {
                objCliente.Id = cliente.Id;
                objCliente.nmCliente = cliente.nmCliente;
                objCliente.cidade = cliente.cidade;


                clientePesquisa.Add(objCliente);
            }

            return View("Index",clientePesquisa);
        }

        [HttpPost]
        public ActionResult InserirCliente(ClientesModel cliente)
        {
            try
            {
                _clienteNegocio.InserirCliente(cliente);

                TempData["Mensagem"] = "3";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["e"] = e.Message;

                return View(cliente);
            }
            
        }

        [HttpPost]
        public ActionResult EditarCliente(ClientesModel cliente)
        {
            try
            {
                _clienteNegocio.EditarCliente(cliente);

                TempData["Mensagem"] = "4";
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["e"] = e.Message;

                return View(cliente);
            }
        }
    }
}
