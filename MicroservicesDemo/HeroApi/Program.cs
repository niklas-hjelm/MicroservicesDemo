using DomainCommons.DTOs;
using DomainCommons.Services;
using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Repositories;
using HeroApi.Extensions;
using HeroApi.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var host = Environment.GetEnvironmentVariable("DB_HOST");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var password = Environment.GetEnvironmentVariable("DB_MSSQL_SA_PASSWORD");
var connectionString = $"Data Source={host};Initial Catalog={database};User ID=sa;Password={password};Trusted_connection=False;TrustServerCertificate=True;";

builder.Services.AddSqlServer<HeroContext>(connectionString);

builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));

builder.Services.AddTransient<IRepository<HeroDto>, Repository>();
builder.Services.AddTransient<IResponseService<HeroDto>, HeroResponseService>();

var app = builder.Build();

app.MapHeroEndpoints();

app.Run();
