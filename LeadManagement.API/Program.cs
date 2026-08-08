using LeadManagement.API.Middleware;
using LeadManagement.Application.Interfaces;
using LeadManagement.Application.Services;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infrastructure.Context;
using LeadManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dapper Context
builder.Services.AddSingleton<DapperContext>();

// Repositories
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IFollowupRepository, FollowupRepository>();

// Services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IFollowupService, FollowupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();