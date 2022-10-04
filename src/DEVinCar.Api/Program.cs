using DEVinCar.Api.Config;
using DEVinCer.DI.IoC;
using DEVinCer.Domain.AutoMapper;
using DEVinCer.Domain.Security;

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

var app = builder.Build();
app.UseMiddleware<ErrorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
