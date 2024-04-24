using Calzolari.Grpc.AspNetCore.FluentValidation;
using Microsoft.EntityFrameworkCore;
using RabbitMQHandler.Services.Impls;
using RabbitMQHandler.Services.Interfaces;
using RoomService.Database;
using RoomService.Repository.Impls;
using RoomService.Repository.Interface;
using RoomService.Services;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddTransient<RoomDbContext>();

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options => options.EnableMessageValidation());
builder.Services.AddGrpcValidation();
builder.Services.AddValidator<RoomValidator>();
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddScoped<IMessageProducer, MessageProducer>();
builder.Services.AddScoped<IMessageConsumer, MessageConsumer>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<RoomDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("RoomDatabase")));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<RoomServiceImpl>();
app.ApplyMigration();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
