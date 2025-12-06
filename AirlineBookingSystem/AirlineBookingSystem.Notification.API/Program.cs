using AirlineBookingSystem.BuildingBlocks.Common;
using AirlineBookingSystem.Notification.Application.Consumers;
using AirlineBookingSystem.Notification.Application.Handlers;
using AirlineBookingSystem.Notification.Core.Repositories;
using AirlineBookingSystem.Notification.Infra.Repositories;
using MassTransit;
using Microsoft.Data.SqlClient;
using System.Data;
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
    typeof(CreateNotificationCommandHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddMassTransit(configs =>
{
    configs.AddConsumer<PaymentProcessConsumer>();

    configs.UsingRabbitMq((ct, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        cfg.ReceiveEndpoint(EventBusConstant.PaymentProcessedQueue, c =>
        {
            c.ConfigureConsumer<PaymentProcessConsumer>(ct);
        });
    });
});

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
