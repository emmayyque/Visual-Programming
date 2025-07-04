using Microsoft.EntityFrameworkCore;
using RestFullWebAPIs.Data;
using RestFullWebAPIs.Models.DataManager;
using RestFullWebAPIs.Models.Entities;
using RestFullWebAPIs.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registerting ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    );

// Registering Repositories
builder.Services.AddScoped<IDataRepository<Student>, StudentDataManager>();

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
