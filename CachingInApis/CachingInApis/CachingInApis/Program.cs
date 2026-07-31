using CachingInApis.Models;
using CachingInApis.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AdventureWorks2014Context>(e =>
{
    e.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
});
builder.Services.AddMemoryCache();
builder.Services.AddMemoryCache(options =>
{
    options.SizeLimit = 1024; // Developer-defined units
});
builder.Services.AddAutoMapper(e =>
{

}, typeof(Program));
builder.Services.AddTransient(typeof(ICacheService<>), typeof(CacheService<>));
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
