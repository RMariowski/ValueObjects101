using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValueObjects101.Application.Orders.Handlers;
using ValueObjects101.Infrastructure.Auth;
using ValueObjects101.Infrastructure.Database;
using ValueObjects101.Infrastructure.Exceptions;
using ValueObjects101.Presentation.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddScoped<ErrorHandlerMiddleware>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<DatabaseContext>()
    .AddMediatR(Assembly.GetExecutingAssembly())
    .AddScoped<IUserContext, UserContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .UseMiddleware<ErrorHandlerMiddleware>()
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapPost("/purchase-orders",
    async (CreatePurchaseOrderRequest request, [FromServices] IMediator mediator,
        [FromServices] IUserContext userContext, CancellationToken cancellationToken) =>
    {
        string createdBy = userContext.GetEmail();
        CreatePurchaseOrder.Command command = new
        (
            request.Lines.Select(line => new CreatePurchaseOrder.Command.Line(line.ArticleId, line.Quantity)),
            request.ContactEmail,
            createdBy
        );
        return await mediator.Send(command, cancellationToken);
    });

app.MapGet("/purchase-orders/{id:long}",
    async (long id, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
    {
        GetPurchaseOrder.Query query = new(id);
        return await mediator.Send(query, cancellationToken);
    });

app.MapPost("/sales-orders",
    async (CreateSalesOrderRequest request, [FromServices] IMediator mediator,
        [FromServices] IUserContext userContext, CancellationToken cancellationToken) =>
    {
        string createdBy = userContext.GetEmail();
        CreateSalesOrder.Command command = new
        (
            request.ContactEmail,
            createdBy
        );
        return await mediator.Send(command, cancellationToken);
    });

app.MapGet("/sales-orders/{id:long}",
    async (long id, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
    {
        GetSalesOrder.Query query = new(id);
        return await mediator.Send(query, cancellationToken);
    });

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await DatabaseSeeder.Seed(dbContext);
}

app.Run();
