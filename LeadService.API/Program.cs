using CollegeLeadService.Application.Interfaces;
using CollegeLeadService.Domain.Interfaces;
using CollegeLeadService.Infrastructure.Repositories;
using Dapper;
using LeadService.Application.Interfaces;
using LeadService.Application.Services;
using LeadService.Domain.Interfaces;
using LeadService.Infrastructure.Data;
using LeadService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService.Application.Services.LeadService>();
builder.Services.AddScoped<ICollegeLeadRepository, CollegeLeadRepository>();

builder.Services.AddScoped<ICollegeLeadService, CollegeLeadService.Application.Services.CollegeLeadService>();
builder.Services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();
builder.Services.AddScoped<ILeadSourceService, LeadService.Application.Services.LeadSourceService>();
//builder.Services.AddScoped<ILeadSourceService, LeadService.Application.Services.LeadSourceService>();

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