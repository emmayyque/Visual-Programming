using Microsoft.EntityFrameworkCore;
using WebAPI_Exam_.Data;
using WebAPI_Exam_.Models;
using WebAPI_Exam_.Models.Entities;
using WebAPI_Exam_.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registering ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    );

// Registering DataManagers
builder.Services.AddScoped<IDataRepository<Bike>, BikeDataManager>();

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
