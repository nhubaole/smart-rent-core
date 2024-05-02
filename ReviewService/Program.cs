using Microsoft.EntityFrameworkCore;
using ReviewService.Database;
using ReviewService.Repository.Impl;
using ReviewService.Repository.Interafaces;
using ReviewService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpc().AddJsonTranscoding();

builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ReviewDBContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("ReviewDatabase")));

var app = builder.Build();
app.ApplyMigration();
// Configure the HTTP request pipeline.
app.MapGrpcService<Review>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
