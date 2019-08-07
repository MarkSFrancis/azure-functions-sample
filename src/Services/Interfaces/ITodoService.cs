using System.Linq;
using System.Threading.Tasks;
using AzureFunctionsSample.Models;

namespace AzureFunctionsSample.Services
{
    public interface ITodoService
    {
        void Delete(TodoModel model);
        TodoModel Get(string id);
        IQueryable<TodoModel> GetAll();
        void Patch(TodoModel model, TodoModel patchWith);
        void Put(TodoModel model);
        Task<int> SaveChanges();
    }
}