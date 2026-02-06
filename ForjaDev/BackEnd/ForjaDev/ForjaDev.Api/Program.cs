using ForjaDev.Api.Extensions;
using ForjaDev.Api.Log;
using ForjaDev.Application.Ioc;
using ForjaDev.Infra.Data.Context;
using ForjaDev.Infra.Ioc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
                       throw new Exception("ConnectionString not found !");

//builder.Logging.AddProvider(new LoggingForjaDev());
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(x => 
        x.UseNpgsql(connectionString, b => b.MigrationsAssembly("ForjaDev.Api")));
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfra();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
    app.UseGlobalExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();