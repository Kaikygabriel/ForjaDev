using ForjaDev.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                       throw new Exception("ConnectionString not found !"); 

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(x => 
        x.UseNpgsql(connectionString, b => b.MigrationsAssembly("ForjaDev.Api")));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
