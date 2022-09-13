using GymEvo.Application;
using GymEvo.Domain.Mapper;
using GymEvo.Infra.Repositories.Interfaces;
using GymEvo.Infra.Repositories.Repositories;
using GymEvo.Infra.SqlServer.Context;
using GymEvo.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependencyInjection();
builder.Services.AddDbContext<ServerContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
    opt => opt.MigrationsAssembly("GymEvo.WebApi"));
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#pragma warning disable CS8603 // Possible null reference return.
builder.Services.AddScoped<IDbContext>(provider => provider.GetService<ServerContext>());
#pragma warning restore CS8603 // Possible null reference return.
builder.Services.AddAutoMapperDependency();

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
