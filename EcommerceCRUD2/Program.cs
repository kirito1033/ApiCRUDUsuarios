using Microsoft.EntityFrameworkCore;
using EcommerceCRUD2.Models;
using EcommerceCRUD2.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión MySQL
var connectionString = builder.Configuration.GetConnectionString("cadenaSQL");
builder.Services.AddDbContext<ecommercetechdbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

// Configurar servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurar controladores y opciones adicionales
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new ActionConverter()); // Comentarlo temporalmente
 
        options.JsonSerializerOptions.MaxDepth = 32; // Opcional si hay relaciones profundas
        options.JsonSerializerOptions.Converters.Add(new ActionConverter()); // Agregar convertidor personalizado
    });

// Configuración para Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // Construir la aplicación después de configurar los servicios

// Configurar el middleware
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAppApi v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
