using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Repositories;
using HeroApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID=sa;Password={password};Trusted_connection=False;TrustServerCertificate=True;";

builder.Services.AddSqlServer<HeroContext>(connectionString);
builder.Services.AddTransient<IHeroRepository, HeroRepository>();

var app = builder.Build();

app.MapHeroEndpoints();


app.Run();
