using AirlineBookingSystem.Flight.Application.Handlers;
using AirlineBookingSystem.Flight.Core.Repositories;
using AirlineBookingSystem.Flight.Infra.Data;
using AirlineBookingSystem.Flight.Infra.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(GetAllFlightsHandler).Assembly,
    typeof(CreateFlightCommandHandler).Assembly,
    typeof(DeleteFlightCommandHandler).Assembly
};

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(assemblies);
});

builder.Services.AddScoped<IFlightRepository, FlightRepository>();

builder.Services.AddScoped<IFlightContext,  FlightContext>();

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
