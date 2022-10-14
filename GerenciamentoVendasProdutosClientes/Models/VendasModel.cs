using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GerenciamentoVendasProdutosClientes.Models
{
    public class VendasModel
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public int idProduto { get; set; }
        public int qtdVenda { get; set; }
        public double vlrUnitarioVenda { get; set; }
        public DateTime dthVenda { get; set; }
        public double vlrTotalVenda { get; set; }

    }
}
