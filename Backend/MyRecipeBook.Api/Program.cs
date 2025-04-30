using MyRecipeBook.Api.Converters;
using MyRecipeBook.Api.Middlewares;
using MyRecipeBook.Infrastructure.Migrations;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header usando o Bearer scheme.
                        Escreva 'Bearer'[espaço] e seu token na caixa de texto abaixo.
                         Exemplo: Bearer 12345sdsdsds",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"

    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme{
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        },

        Scheme = "oauth2",
        Name = "Bearer",
        In = ParameterLocation.Header
     },
        new List<string>()
        }
    });
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddRouting(option => option.LowercaseUrls = true);

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

    if (connectionString != null)
    {
        MigrateDatabase.EnsureDatabaseIsCreated(connectionString);
    }
}