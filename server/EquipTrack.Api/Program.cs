using EquipTrack.Api.Middlewares;
using EquipTrack.Application.DTOs;
using EquipTrack.Application.Interfaces;
using EquipTrack.Application.Mappings;
using EquipTrack.Infrastructure;
using EquipTrack.Infrastructure.DataSeeding;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();
builder.Services.AddCustomValidators();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
await dbInitializer.SeedDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapGet("/api/devices", async (IDeviceRepository deviceRepository, CancellationToken cancellationToken) =>
{
    var devices = await deviceRepository.GetAllDevicesAsync(cancellationToken);
    var dtos = devices.Select(device => device.ToResponseDto());

    return Results.Ok(dtos);
});

app.MapPost("/api/devices", async (
    CreateDeviceRequest request,
    IValidator<CreateDeviceRequest> validator,
    IDeviceRepository deviceRepository,
    CancellationToken cancellationToken) =>
{
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (!validationResult.IsValid)
        return Results.ValidationProblem(validationResult.ToDictionary());

    var newDevice = request.ToDevice();

    await deviceRepository.AddAsync(newDevice, cancellationToken);

    return Results.Created($"/api/devices/{newDevice.Id}", newDevice.ToResponseDto());
});

app.Run();
