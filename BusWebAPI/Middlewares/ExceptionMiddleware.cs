using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Application.Exceptions;
using BusWebAPI.Domain.Common;
using Newtonsoft.Json;
using System.Net;

namespace BusWebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;
        private readonly IUserRepository _userRepository;

        public ExceptionMiddleware(RequestDelegate next)//, Serilog.ILogger logger, IUserRepository userRepository)
        {
            _next = next;
            //_logger = logger;
            //_userRepository = userRepository;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;
                switch (e)
                {
                    case NotFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        result = JsonConvert.SerializeObject(new Response<IDictionary<string, string[]>>()
                        {
                            Message = e.Message,
                            StatusCode = (short)statusCode,
                            Success = false,
                        });
                        //_logger.Error("NotFoundException", e);
                        break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new Response<IDictionary<string, string[]>>()
                        {
                            Message = e.Message,
                            StatusCode = (short)statusCode,
                            Success = false,
                            Data = validationException.Errors
                        });
                        //_logger.Error("ValidationException", e);
                        break;
                    case BadRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new Response<string>()
                        {
                            StatusCode = (short)statusCode,
                            Success = false,
                            Message = e.Message,
                        });
                        //_logger.Error("BadRequestException", e);
                        break;
                    case ArgumentNullException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new Response<string>()
                        {
                            StatusCode = (short)statusCode,
                            Success = false,
                            Message = e.Message,
                        });
                        //_logger.Error("ArgumentNullException", e);
                        break;
                    default:
                        //_logger.Error("Exception", e);
                        break;
                }
                
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
