using AccountService.Database;
using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using RabbitMQHandler.Services.Impls;
using RabbitMQHandler.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddDbContext<AccountDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("UserDatabase")));

builder.Services.AddScoped<IMessageProducer, MessageProducer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
//app.ApplyMigration();

app.MapControllers();

app.Run();
