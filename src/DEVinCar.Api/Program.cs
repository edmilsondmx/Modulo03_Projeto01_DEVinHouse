using DEVinCar.Api.Config;
using DEVinCer.DI.IoC;
using DEVinCer.Domain.AutoMapper;
using DEVinCer.Domain.Security;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(CacheService<>));

builder.Services.AddSingleton(AutoMapperConfig.Configure());

builder.Services.RegisterAuthentication();


builder.Services.AddMvc( config => {
    config.ReturnHttpNotAcceptable = true;
    config.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
    config.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(config));
});

builder.Services.AddSwaggerGen( options => 
{
    options.SwaggerDoc("v1", 
        new OpenApiInfo
        {
            Title = "DEVinCar.Api",
            Version = "v1",
            Description = "Api desenvolvida para DEVinHouse!",
            Contact = new OpenApiContact
            {
                Name = "Edmilson Gomes",
                Url = new Uri("https://github.com/edmilsondmx"),
                Email = "edmilsondmx@gmail.com",
            }
        });
});

var app = builder.Build();
app.UseMiddleware<ErrorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
