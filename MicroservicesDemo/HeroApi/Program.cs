using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Repositories;
using HeroApi.Endpoints;
using HeroApi.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID=sa;Password={password};Trusted_connection=False;TrustServerCertificate=True;";

builder.Services.AddSqlServer<HeroContext>(connectionString);

builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));

builder.Services.AddTransient<IHeroRepository, HeroRepository>();
builder.Services.AddTransient<IHeroResponseService, HeroResponseService>();

var app = builder.Build();

app.MapHeroEndpoints();

app.Run();
