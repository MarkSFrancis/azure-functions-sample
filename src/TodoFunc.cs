using AzureFunctionsSample.Models;
using AzureFunctionsSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Linq;

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
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo")] HttpRequest _)
        {
            var all = TodoService.GetAll().ToList();

            return Ok(all);
        }

        [FunctionName("TodoGet")]
        public IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Todo/{id}")] HttpRequest _, string id)
        {
            return Ok(id);
        }

        [FunctionName("TodoPut")]
        public IActionResult Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "Todo/{id}")] TodoModel model, string id)
        {
            var state = Validate(model);

            if (!state.IsValid)
            {
                return BadRequest(state);
            }

            return Ok(model);
        }

        [FunctionName("TodoPatch")]
        public IActionResult Patch(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = "Todo/{id}")] TodoModel model)
        {
            var state = Validate(model);

            if (!state.IsValid)
            {
                return BadRequest(state);
            }

            return Ok(model);
        }

        [FunctionName("TodoDelete")]
        public IActionResult Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Todo/{id}")] TodoModel model)
        {
            var state = Validate(model);

            if (!state.IsValid)
            {
                return BadRequest(state);
            }

            return Ok(model);
        }
    }
}
