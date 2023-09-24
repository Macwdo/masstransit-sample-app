
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5001");

builder.Services.AddMassTransit(x =>
{

    x.SetKebabCaseEndpointNameFormatter();

    var assembly = typeof(Program).Assembly;

    x.AddConsumers(assembly);

    x.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ConfigureEndpoints(context);
    });

});

var app = builder.Build();
app.Run();
