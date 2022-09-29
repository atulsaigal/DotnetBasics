using CarWebApi.WebApp._2_Services.ServiceLogic;
using CarWebApi.WebApp._2_Services.ServicesInterface;
using CarWebApi.WebApp._3_BusinessLogic.BusinessInterface;
using CarWebApi.WebApp._3_BusinessLogic.BusinessLogic;
using CarWebApi.WebApp._4_DataAccess;
using CarWebApi.WebApp._4_DataAccess.Repository;
using CarWebApi.WebApp._4_DataAccess.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CarServicesInterface, ServiceClass>();
builder.Services.AddTransient<CarBusinessInterface, BusinessClass>();
builder.Services.AddTransient<CarRepositoryInterface, CarRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));


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
