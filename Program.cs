using ColdConnectNET.API.Data; // Namespace do seu DbContext
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization; // Necessário para ReferenceHandler

var builder = WebApplication.CreateBuilder(args);

// ⬇️ Configurar o Oracle + EF Core
builder.Services.AddDbContext<ColdContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// ⬇️ Adicionar suporte a Controllers + Views (MVC) com ReferenceHandler.Preserve
builder.Services.AddControllersWithViews()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
    );

// ⬇️ Adicionar Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ⬇️ Configurações de tratamento de erros e HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ⬇️ Middleware padrão
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ⬇️ Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⬇️ Rota padrão MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
