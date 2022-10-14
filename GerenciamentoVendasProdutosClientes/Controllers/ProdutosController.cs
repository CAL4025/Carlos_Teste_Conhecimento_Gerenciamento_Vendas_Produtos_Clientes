using GerenciamentoVendasProdutosClientes.Models;
using GerenciamentoVendasProdutosClientes.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoVendasProdutosClientes.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly IProdutosNegocio _produtoNegocio;

        public ProdutosController(IProdutosNegocio produtoNegocio)
        {
            _produtoNegocio = produtoNegocio;
        }
        public IActionResult Index(List<ProdutosModel> produtos)
        {
            produtos = _produtoNegocio.BuscarTodos();

            return View(produtos);

        } 
        
        public IActionResult InserirProduto()
        {
            return View();

        } 
        
        public IActionResult EditarProduto(int id)
        {
            ProdutosModel produto = _produtoNegocio.ListarPorId(id);

            return View(produto);

        } 
        
        public ActionResult ExcluirProduto(int id)
        {

            if (_produtoNegocio.ExcluirProduto(id))
            {
                TempData["Mensagem"] = "1";
            }
            else
            {
                TempData["Mensagem"] = "2";
            }

            return RedirectToAction("Index");
        }

        public ActionResult PesquisarProduto(string nome)
        {
            List<ProdutosModel> produtoPesquisa = new List<ProdutosModel>();
            ProdutosModel objProduto = new ProdutosModel();

            

            List<ProdutosModel> produtos = _produtoNegocio.BuscarTodos();

            var pesquisa = produtos.Where(prod => prod.dscProduto == nome).ToList();

            foreach (var produto in pesquisa)
            {
                objProduto.Id = produto.Id;
                objProduto.dscProduto = produto.dscProduto;
                objProduto.vlrUnitario = produto.vlrUnitario;


                produtoPesquisa.Add(objProduto);
            }

            return View("Index", produtoPesquisa);
        }

        [HttpPost]
        public IActionResult InserirVenda(ProdutosModel produto)
        {
            try
            {
                _produtoNegocio.InserirVenda(produto);

                TempData["Mensagem"] = "3";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["e"] = e.Message;

                return View(produto);
            }
        }

        [HttpPost]
        public IActionResult EditarVenda(ProdutosModel produto)
        {
            try
            {
                _produtoNegocio.EditarVenda(produto);

                TempData["Mensagem"] = "4";

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["e"] = e.Message;

                return View(produto);
            }
        }
    }
}
