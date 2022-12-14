using DomainCommons.DTOs;
using DomainCommons.Services;
using MediatR;
using VillainApi.DataAccess;
using VillainApi.DataAccess.Repositories;
using VillainApi.Extensions;
using VillainApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IRepository<VillainDto>, Repository>();
builder.Services.AddScoped<IResponseService<VillainDto>, VillainResponseService>();
builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));
var app = builder.Build();

app.MapVillainEndpoints();

app.Run();
