﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Abstractions.Interfaces;
using OpenAI.Implementations.Options;
using OpenAI.Implementations.Services;
using WebClient.Implementations;

namespace OpenAI.Implementations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOpenAI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenAIOptions>(configuration.GetSection("OpenAIOptions"));

            services.AddWebClient(configuration);

            services.AddTransient<IOpenAIService, OpenAIService>();

            return services;
        }
    }
}
