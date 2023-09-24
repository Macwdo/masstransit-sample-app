// See https://aka.ms/new-console-template for more information

using Customer.Api.Customers;
using Customer.Api.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(dbConnectionString);
});

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

app.MapGet("/", async (ICustomerService service) =>
{
    var customers = await service.GetCustomers();
    return customers;
});

app.MapGet("/{id:guid}", async (ICustomerService service, Guid id) =>
{
    var customer = await service.GetCustomer(id);
    return customer;
});

app.MapPost("/", async (ICustomerService service, Customer.Api.Customers.Customer customer) =>
{
    await service.AddCustomer(customer);
    return customer;
});

app.MapPut("/", async (ICustomerService service, Customer.Api.Customers.Customer customer) =>
{
    await service.UpdateCustomer(customer);
    return customer;
});

app.MapDelete("/{id:guid}", async (ICustomerService service, Guid id) =>
{
    await service.DeleteCustomer(id);
    return Results.Ok();
});

app.Run();

