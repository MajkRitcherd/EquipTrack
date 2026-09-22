using EquipTrack.Application.Interfaces;
using EquipTrack.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/devices", async (IDeviceRepository deviceRepository, CancellationToken cancellationToken) =>
{
   var devices = await deviceRepository.GetAllDevicesAsync(cancellationToken);
   return Results.Ok(devices);
});

app.Run();
