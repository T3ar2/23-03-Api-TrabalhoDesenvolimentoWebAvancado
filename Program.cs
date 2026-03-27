using Microsoft.EntityFrameworkCore;
using ProdutosApi;

var builder = WebApplication.CreateBuilder(args);

var conn = builder
            .Configuration
            .GetConnectionString("ConnPadrao");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

//Criando politica de Cors
builder.Services.AddCors(options => {
    //.WhithOrigins("https://localhost:300")
    options.AddPolicy("Liberado", policy => {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 
app.UseCors("Liberado"); 
app.UseAuthorization();
app.MapControllers(); 

app.Run();

