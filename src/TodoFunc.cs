using AzureFunctionsSample.Models;
using AzureFunctionsSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace AzureFunctionsSample
{
    public class TodoFunc : FuncBase
    {
        public ITodoService TodoService { get; }

        public TodoFunc(ITodoService todoService)
        {
            TodoService = todoService;
        }

        [FunctionName("TodoGetAll")]
        public IActionResult GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo")] HttpRequest req)
        {
            var all = TodoService.GetAll().ToList();

            return Ok(all);
        }

        [FunctionName("TodoGet")]
        public IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo/{id}")] HttpRequest req, string id)
        {
            var model = TodoService.Get(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [FunctionName("TodoPost")]
        public async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Todo")] TodoModel model)
        {
            var state = Validate(model);

            if (!state.IsValid)
            {
                return BadRequest(state);
            }

            TodoService.Post(model);

            await TodoService.SaveChanges();

            return Ok(model);
        }

        [FunctionName("TodoPut")]
        public async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Todo/{id}")] TodoModel model, string id)
        {
            var state = Validate(model);

            if (!state.IsValid)
            {
                return BadRequest(state);
            }

            model.Id = id;
            TodoService.Put(model);

            await TodoService.SaveChanges();

            return Ok(model);
        }

        [FunctionName("TodoPatch")]
        public async Task<IActionResult> Patch(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "Todo/{id}")] TodoModel model, string id)
        {
            var patch = TodoService.Get(id);

            if (patch is null)
            {
                return NotFound();
            }

            TodoService.Patch(patch, model);

            await TodoService.SaveChanges();

            return NoContent();
        }

        [FunctionName("TodoDelete")]
        public async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Todo/{id}")] HttpRequest req, string id, ILogger logger)
        {
            var match = TodoService.Get(id);

            TodoService.Delete(match);

            if (match != null)
            {
                logger.LogInformation("Todo " + id + " deleted");
            }

            await TodoService.SaveChanges();

            return NoContent();
        }
    }
}
