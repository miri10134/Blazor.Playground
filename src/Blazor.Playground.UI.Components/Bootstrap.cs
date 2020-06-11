using Blazor.Playground.Contract.Services;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    public static class Bootstrap
    {
        public static IServiceCollection AddComponents(this IServiceCollection services)
        {
            services.TryAddSingleton<IRandomGenerator, RandomGenerator>();
            services.TryAddSingleton<IStateService, StateService>();

            return services;
        }
    }
}
