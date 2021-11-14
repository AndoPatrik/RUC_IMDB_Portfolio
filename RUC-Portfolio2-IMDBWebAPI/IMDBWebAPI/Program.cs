using Application.Interfaces.v1.Repositories;
using Application.Services.v1.AuthService.Command;
using IMDB.Application.Requests;
using Infrastructure.Context;
using Infrastructure.Repositories.v1.AuthService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MEDIATR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

//DB CONNECTION
builder.Services.AddDbContext<imdbContext>(ctx => ctx.UseNpgsql(builder.Configuration.GetConnectionString("Development")));

//SERVICES
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

//HANDLERS
builder.Services.AddScoped<IRequestHandler<AuthenticateCommand, AuthInstance>, AuthenticateCommandHandler>();


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
