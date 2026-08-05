using EnquiryService.Application.Interfaces;
using EnquiryService.Domain.Interfaces;
using EnquiryService.Infrastructure.Repositories;
using EnquiryService.Infrastructure.Data;
using EnquiryService.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IEnquiryRepository, EnquiryRepository>();

//builder.Services.AddScoped<IEnquiryService, EnquiryService>();                                                                

builder.Services.AddScoped<IEnquiryService, EnquiryService.Application.Services.EnquiryService>();
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