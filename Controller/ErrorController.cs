using System.Net.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Controller
{
    // ErrorController handles exceptions
    // that was raised during the program execution
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            if (exceptionHandlerFeature.Error is HttpRequestException exception)
            {
                var result = Problem(statusCode: (int?)exception.StatusCode, detail: exception.Message);

                return result;
            }
            else
            {
                var result = Problem();

                return result;
            }
        }
    }
}
