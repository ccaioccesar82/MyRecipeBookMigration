using Microsoft.Extensions.Configuration;
using MyRecipeBook.Api.Middlewares;
using MyRecipeBook.Application;
using MyRecipeBook.Infrastructure;
using MyRecipeBook.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureLanguage>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ValidateMyDatabase(builder.Configuration);

app.Run();


void ValidateMyDatabase(IConfiguration configuration)
{

    string? connectionString = configuration.GetConnectionString("Connection");

    MigrateDatabase.EnsureDatabaseIsCreated(connectionString);
    
}