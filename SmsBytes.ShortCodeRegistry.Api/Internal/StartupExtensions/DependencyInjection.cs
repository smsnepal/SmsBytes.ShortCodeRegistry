using SmsBytes.ShortCodeRegistry.Storage;
using Microsoft.Extensions.DependencyInjection;
using SmsBytes.ShortCodeRegistry.Common.Uuid;

namespace SmsBytes.ShortCodeRegistry.Api.Internal.StartupExtensions
{
    public static class DependencyInjection
    {
        public static void ConfigureRequiredDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationContext>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddSingleton<IUuidService, UuidService>();
        }
    }
}