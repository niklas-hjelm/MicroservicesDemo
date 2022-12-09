using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Repositories;
using HeroApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<HeroContext>(builder.Configuration.GetConnectionString("HeroDb"));
builder.Services.AddTransient<HeroContext>();
builder.Services.AddTransient<IHeroRepository, HeroRepository>();

var app = builder.Build();

app.MapHeroEndpoints();


app.Run();
