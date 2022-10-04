using System.Net;
using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Exceptions;

namespace DEVinCar.Api.Config;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await TratamentoExcecao(context, ex);
        }
        
    }

    private Task TratamentoExcecao(HttpContext context, Exception ex)
    {
        HttpStatusCode status;
        string message;

        if(ex is IsExistsException)
        {
            status = HttpStatusCode.NotFound;
            message = ex.Message;
        }
        else if(ex is BadRequestException)
        {
            status = HttpStatusCode.BadRequest;
            message = ex.Message;
        }
        else if(ex is NotAcceptableException)
        {
            status = HttpStatusCode.NotAcceptable;
            message = ex.Message;
        }
        else if(ex is AutenticationException)
        {
            status = HttpStatusCode.Forbidden;
            message = ex.Message;
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = "An error has occurred, please contact TI!";
        }


        var response = new ErrorDTO(message);

        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsJsonAsync(response);
    }
}
