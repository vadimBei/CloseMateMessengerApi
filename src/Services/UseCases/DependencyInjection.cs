using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, Assembly executingAssembly, IConfiguration configuration)
        {
            services.AddAutoMapper(executingAssembly, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddMediatR(executingAssembly, Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
