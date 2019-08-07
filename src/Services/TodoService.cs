using AzureFunctionsSample.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AzureFunctionsSample.Services
{
    public class TodoService : ITodoService
    {
        public TodoService(AzureFunctionsSampleContext appContext)
        {
            AppContext = appContext;
        }

        protected AzureFunctionsSampleContext AppContext { get; }

        public IQueryable<TodoModel> GetAll()
        {
            return AppContext.Todos;
        }

        public TodoModel Get(string id)
        {
            return AppContext.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Post(TodoModel model)
        {
            AppContext.Todos.Add(model);
        }

        public void Patch(TodoModel model, TodoModel patchWith)
        {
            if (patchWith.CompletedOn.HasValue)
            {
                model.CompletedOn = patchWith.CompletedOn;
            }

            if (!string.IsNullOrWhiteSpace(patchWith.Name))
            {
                model.Name = patchWith.Name;
            }
        }

        public void Put(TodoModel model)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TodoModel> tracker = AppContext.Attach(model);
            tracker.State = EntityState.Modified;
        }

        public void Delete(TodoModel model)
        {
            if (model is null)
            {
                return;
            }

            AppContext.Remove(model);
        }

        public Task<int> SaveChanges()
        {
            return AppContext.SaveChangesAsync();
        }
    }
}
