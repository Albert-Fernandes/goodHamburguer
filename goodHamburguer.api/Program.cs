using goodHamburguer.api.Application.Services;
using goodHamburguer.api.Domain.Entities;
using goodHamburguer.api.Domain.Enums;
using goodHamburguer.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("GoodHamburguerDb"));
builder.Services.AddScoped<IPedidoDescontoService, PedidoDescontoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    if (!context.Produtos.Any())
    {
        context.Produtos.AddRange(
            new Produto("X-Burger", 5.00m, CategoriaProduto.Hamburguer),
            new Produto("X-Bacon", 7.00m, CategoriaProduto.Hamburguer),
            new Produto("Batata Frita", 2.00m, CategoriaProduto.Fritas),
            new Produto("Refrigerante", 2.50m, CategoriaProduto.Refrigerante)
        );
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
