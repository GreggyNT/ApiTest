using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestApi.Context;
using TestApi.Dtos;
using TestApi.Entities;
using TestApi.Services;
using TestApi.Services.ExceptionHandler;
using TestApi.Services.Repo_Unit;
using TestApi.Services.Repo_Unit.Interfaces;
using TestApi.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped < IRedisHash, RedisHash > ();
builder.Services.AddDbContext<ApiContext>(opt => opt.UseNpgsql("Server=localhost;Database=test;Port=5432;User Id =postgres;Password=postgres;"));
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IEventParticipantRepository, EventParticipantRepository>();
builder.Services.AddTransient<IRepository<Participant>, ParticipantRepository>();
builder.Services.AddTransient<IValidator<EventDto>, EventValidator>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
