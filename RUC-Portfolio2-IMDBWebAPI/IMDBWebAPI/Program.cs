using Application.Interfaces.v1.Repositories;
using Application.Services.v1.AuthService.Command;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using IMDB.Application.Requests;
using IMDB.Application.Services.v1.UsersService;
using IMDB.Application.Services.v1.UsersService.Command;
using IMDB.Infrastructure.Repositories.v1.AuthService;
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

//REGISTER REPOSITORIES
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

//REGISTER HANDLERS
builder.Services.AddScoped<IRequestHandler<AuthenticateCommand, AuthInstance>, AuthenticateCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CreateUserCommand, ResponseMessage>, CreateUserCommandHandler>();

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
