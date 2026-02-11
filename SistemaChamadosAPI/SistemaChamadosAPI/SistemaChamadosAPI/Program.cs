using Microsoft.EntityFrameworkCore;
// 1. ESTE É O 'using' QUE FALTAVA OU ESTAVA ERRADO:
// Ele deve apontar para onde o seu AppDbContext.cs está (a pasta 'Data')
using SistemaChamadosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container
builder.Services.AddControllers();

// Configura Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Esta linha está correta e agora vai funcionar
// porque o 'using' da linha 4 foi corrigido.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();