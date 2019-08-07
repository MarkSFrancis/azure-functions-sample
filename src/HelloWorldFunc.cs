using AzureFunctionsSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureFunctionsSample
{
    public static class HelloWorldFunc
    {
        [FunctionName("HelloWorld")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HelloWorldModel model)
        {
            if (model?.Name is null)
            {
                return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }

            return new OkObjectResult($"Hello, {model.Name}");
        }
    }
}
