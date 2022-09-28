using System.Text.Json.Serialization;
using DEVinCar.Infra.Data;
using DEVinCer.DI.Autentication;
using DEVinCer.DI.IoC;
using DEVinCer.Domain.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(AutoMapperConfig.Configure());

builder.Services.RegisterAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
