using System.Net;
using ValueObjects101.Domain.Shared.Exceptions;

namespace ValueObjects101.Infrastructure.Exceptions;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleErrorAsync(context, exception);
        }
    }

    private async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode;
        ErrorDto error;

        switch (exception)
        {
            case ValueObjects101Exception valueObjects101Exception:
                httpStatusCode = HttpStatusCode.BadRequest;
                error = new ErrorDto(valueObjects101Exception.Code, valueObjects101Exception.Message);
                break;

            case OperationCanceledException operationCanceledException:
                httpStatusCode = HttpStatusCode.BadRequest;
                error = new ErrorDto("OperationCanceled", operationCanceledException.Message);
                break;

            default:
                _logger.LogError(exception, exception.Message);
                httpStatusCode = HttpStatusCode.InternalServerError;
                error = new ErrorDto("InternalError", exception.Message);
                break;
        }

        await WriteObjectToResponseAsync(context, httpStatusCode, error);
    }

    private static Task WriteObjectToResponseAsync(HttpContext context, HttpStatusCode statusCode, object obj)
    {
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsJsonAsync(obj);
    }
}
