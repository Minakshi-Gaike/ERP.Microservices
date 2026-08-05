using LeadService.Application.Interfaces;
using LeadService.Domain.Interfaces;
using LeadService.Infrastructure.Data;
using LeadService.Infrastructure.Repositories;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService.Application.Services.LeadService>();
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();