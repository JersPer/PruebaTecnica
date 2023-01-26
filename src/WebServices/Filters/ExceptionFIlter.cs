using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PruebaMedismart.Application.Common.Exceptions;
using PruebaMedismart.Application.Common.Models;

namespace WebServices.Filters;
public class ExceptionFilter : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                { typeof(NotFoundException), HandleNotFoundException }
            };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        context.Result = new JsonResult(
            new ErrorResponse{ ErrorMessage = "Internal server error, try again.", ErrorCode="500" });
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            context.ExceptionHandled = true;
        }
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = (NotFoundException)context.Exception;
        context.Result = new JsonResult(
            new ErrorResponse { ErrorMessage = exception.Message, ErrorCode = "404" });
        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
    }
}