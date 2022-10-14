using GerenciamentoVendasProdutosClientes.Models;
using GerenciamentoVendasProdutosClientes.Negocio;
using Microsoft.AspNetCore.Mvc;


namespace GerenciamentoVendasProdutosClientes.Controllers
{
    public class VendasController : Controller
    {

        private readonly IVendasNegocio _vendaNegocio;
        private readonly IClientesNegocio _clientesNegocio;
        private readonly IProdutosNegocio _produtosNegocio;

        public VendasController(IVendasNegocio vendaNegocio, IClientesNegocio clientesNegocio, IProdutosNegocio produtosNegocio)
        {
            _vendaNegocio = vendaNegocio;
            _clientesNegocio = clientesNegocio;
            _produtosNegocio = produtosNegocio;
        }
        public ActionResult Index()
        {
            List<VendasModel> vendas = _vendaNegocio.BuscarTodos();

            return View(vendas);
        }

        public ActionResult InserirVenda()
        {
            return View();
        }
        
        public IActionResult EditarVenda(int id)
        {

            VendasModel venda = _vendaNegocio.ListarPorId(id);

            return View(venda);
        }
        
        public ActionResult ExcluirVenda(int id)
        {
            if (_vendaNegocio.ExcluirVenda(id))
            {
                TempData["Mensagem"] = "1";
            }
            else
            {
                TempData["Mensagem"] = "2";
            }

            return RedirectToAction("Index");
        }

        public ActionResult PesquisarVenda(string nome)
        {
            List<VendasModel> vendaPesquisa = new List<VendasModel>();
            VendasModel objVenda = new VendasModel();

            List<VendasModel> vendas =_vendaNegocio.BuscarTodos();

            List<ClientesModel> clientes = _clientesNegocio.BuscarTodos();

            List<ProdutosModel> produtos = _produtosNegocio.BuscarTodos();

            var pesquisa = (from venda in vendas
                               join cliente in clientes
                               on venda.idCliente equals cliente.Id
                               join produto in produtos
                               on venda.idProduto equals produto.Id
                               where cliente.nmCliente == nome || produto.dscProduto == nome
                               select venda).ToList();

            vendas.Clear();

            foreach(var venda in pesquisa)
            {
                objVenda.Id = venda.Id;
                objVenda.idCliente = venda.idCliente;
                objVenda.idProduto = venda.idProduto;   
                objVenda.qtdVenda = venda.qtdVenda;
                objVenda.vlrUnitarioVenda = venda.vlrUnitarioVenda;
                objVenda.vlrTotalVenda = venda.vlrTotalVenda;
                objVenda.dthVenda = venda.dthVenda;

                vendas.Add(objVenda);
            }

            return View("Index", vendas);
        }

        [HttpPost]
        public ActionResult InserirVenda(VendasModel venda)
        {
            try
            {
                ProdutosModel produto = _produtosNegocio.ListarPorId(venda.idProduto);

                venda.vlrUnitarioVenda = produto.vlrUnitario;
                venda.vlrTotalVenda = (venda.qtdVenda * venda.vlrUnitarioVenda);

                _vendaNegocio.InserirVenda(venda);

                TempData["Mensagem"] = "3";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["e"] = e.Message;

                return View(venda);
            }
        }

        [HttpPost]
        public ActionResult EditarVenda(VendasModel venda)
        {
            try
            {
                _vendaNegocio.EditarVenda(venda);

                TempData["Mensagem"] = "4";

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["e"] = e.Message;

                return View(venda);
            }
        }
    }
}
