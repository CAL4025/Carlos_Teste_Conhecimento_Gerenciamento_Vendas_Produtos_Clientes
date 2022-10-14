
using GerenciamentoVendasProdutosClientes.Data;
using GerenciamentoVendasProdutosClientes.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BancoContext>
    (options => options.UseSqlServer("Data Source=DESKTOP-HVQS68O\\SQLEXPRESS;Initial Catalog=Gerenciamento_Vendas_Produtos_Cliente;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));

builder.Services.AddScoped<IVendasNegocio, VendasNegocio>();
builder.Services.AddScoped<IProdutosNegocio, ProdutosNegocio>();
builder.Services.AddScoped<IClientesNegocio, ClientesNegocio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




