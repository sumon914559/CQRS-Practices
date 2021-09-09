using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Appication
{
    public static class ApplicationDependency
    {
        public static void ApplicationDependencyInjector(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        
    }
}