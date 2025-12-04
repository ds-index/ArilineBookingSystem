using System.Data;
using System.Reflection;
using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Handlers;
using AirlineBookingSystem.Booking.Core.Repositories;
using AirlineBookingSystem.Booking.Infra.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(CreateBookingHandler).Assembly,
    typeof(GetBookingHandler).Assembly
};

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(assemblies);
});

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IDbConnection>(sp =>
new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
