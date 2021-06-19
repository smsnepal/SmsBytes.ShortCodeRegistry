using Microsoft.Extensions.DependencyInjection;
using SmsBytes.ShortCodeRegistry.Api.Internal.Workers;

namespace SmsBytes.ShortCodeRegistry.Api.Internal.StartupExtensions
{
    public static class Workers
    {
        public static void RegisterWorker(this IServiceCollection services)
        {
            services.AddHostedService<Worker>();
        }
    }
}
