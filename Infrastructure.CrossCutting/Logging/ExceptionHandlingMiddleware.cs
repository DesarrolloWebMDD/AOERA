using System;
using System.IO;
using System.Threading.Tasks;
using Infrastructure.CrossCutting.CustomExections;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace Infrastructure.CrossCutting.Logging
{
    public class ExceptionHandlingMiddleware
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
            _logger = Log.Logger;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (ControlledException ex)
            {
                var completeMessage = GetCompleteExceptionMessage(ex);
                _logger.Error($"{completeMessage}\n{ex.StackTrace}");

                context.Response.ContentType = "application/json";

                await using var writer = new StreamWriter(context.Response.Body);
                var jsonSerilizer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                jsonSerilizer.Serialize(writer, new JsonResult<object>(false, ex.Message));

                await writer.FlushAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var completeMessage = GetCompleteExceptionMessage(ex);
                _logger.Error($"{completeMessage}\n{ex.StackTrace}");

                context.Response.ContentType = "application/json";

                await using var writer = new StreamWriter(context.Response.Body);
                var jsonSerilizer = new JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                if (bool.Parse(_configuration.GetSection("ExceptionSettings:ShowCustomMessage").Value))
                    completeMessage = _configuration.GetSection("ExceptionSettings:CustomMessage").Value;
                jsonSerilizer.Serialize(writer, new JsonResult<object>(false, completeMessage));

                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

        private string GetCompleteExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;
            var errorMessage = $"{ex.Message}\n{GetCompleteExceptionMessage(ex.InnerException)}";

            return errorMessage;
        }
    }
}