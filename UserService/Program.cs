using RabbitMQHandler.Services.Impls;
using RabbitMQHandler.Services.Interfaces;
using Calzolari.Grpc.AspNetCore.FluentValidation;
using Microsoft.EntityFrameworkCore;
using UserService.Database;
using UserService.Repository;
using UserService.Services;
using AutoMapper;
using RoomService.Database;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options => options.EnableMessageValidation());
builder.Services.AddGrpcValidation();
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddScoped<IMessageProducer, MessageProducer>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<UserDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("UserDatabase")));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserServiceImpl>();
app.ApplyMigration();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
