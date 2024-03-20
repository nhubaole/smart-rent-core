using Google.Api;
using Microsoft.EntityFrameworkCore;
using RoomService.Data;
using RoomService.Repository.Impls;
using RoomService.Repository.Interface;
using RoomService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RoomDbContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("RoomDatabase")));
//builder.Services.AddDbContext<RoomDbContext>();

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<RoomServiceImpl>();
app.ApplyMigration();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
