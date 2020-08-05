using Trackings.API.Schedulers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBackgroundTasks(this IServiceCollection services) =>
            services.AddHostedService<LogHostedService>();
    }
}
