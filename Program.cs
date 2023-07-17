using Microsoft.EntityFrameworkCore;
using Npgsql;
using PFM.Database;
using PFM.Database.Repositories;
using PFM.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// AutoMapper definition
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TransactionDbContext>(opt =>
{
    opt.UseNpgsql(CreateConnectionString(builder.Configuration));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

string CreateConnectionString(IConfiguration configuration)
{
    var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "sa";
    var pass = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "Password123#";
    var databaseName = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? "transactions";
    var host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
    var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";

    var connBuilder = new NpgsqlConnectionStringBuilder
    {
        Host = host,
        Port = int.Parse(port),
        Username = username,
        Database = databaseName,
        Password = pass,
        Pooling = true
    };

    return connBuilder.ConnectionString;
}