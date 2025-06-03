using A12WebAPIs.Data;
using A12WebAPIs.Models;
using A12WebAPIs.Models.Entities;
using A12WebAPIs.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registering ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    );

// Regisgtering Data Repositories
builder.Services.AddScoped<IDataRepository<Department>, DepartmentDataManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
