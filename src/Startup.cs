using AzureFunctionsSample.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionsSample.Startup))]

namespace AzureFunctionsSample
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IServiceCollection services = builder.Services;

            services.AddDbContext<AzureFunctionsSampleContext>(options => options.UseInMemoryDatabase("_"));
            services.AddTransient<ITodoService, TodoService>();
        }
    }
}
