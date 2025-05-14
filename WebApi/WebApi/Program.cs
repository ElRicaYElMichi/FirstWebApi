using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Services;
var builder = WebApplication.CreateBuilder(args);


// variable para cadena de conection 
var connectionString = builder.Configuration.GetConnectionString("Connection");

// registrar servicio para la conexion (** para controllers )
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injectando los servicios 
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<ReactionService>();

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
