using AzureFunctionsSample.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctionsSample.Services
{
    public class AzureFunctionsSampleContext : DbContext
    {
        public AzureFunctionsSampleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoModel> Todos { get; set; }
    }
}
