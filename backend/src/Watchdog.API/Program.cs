using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

// ---------------- LOGS ----------------
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// ---------------- SERVICES ----------------
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (React)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// DbContext
/*builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);*/

// Dependency Injection
//builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// ---------------- PIPELINE ----------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReact");
app.UseAuthorization();
app.MapControllers();

app.Run();
