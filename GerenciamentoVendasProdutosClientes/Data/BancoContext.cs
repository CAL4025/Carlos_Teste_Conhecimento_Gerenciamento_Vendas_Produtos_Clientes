using GerenciamentoVendasProdutosClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoVendasProdutosClientes.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<VendasModel> Vendas { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<ClientesModel> Clientes { get; set; }
    }
}
