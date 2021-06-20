using Microsoft.Extensions.Configuration;
using SmsBytes.ShortCodeRegistry.Storage;
using Microsoft.Extensions.DependencyInjection;
using SmsBytes.ShortCodeRegistry.Business;
using SmsBytes.ShortCodeRegistry.Business.ApplicationInfo;
using SmsBytes.ShortCodeRegistry.Common.Uuid;

namespace SmsBytes.ShortCodeRegistry.Api.Internal.StartupExtensions
{
    public static class DependencyInjection
    {
        public static void ConfigureRequiredDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationContext>();
            services.AddSingleton<IUuidService, UuidService>();
            services.AddTransient<IShortCodeRepository, ShortCodeRepository>();
            services.AddTransient<IShortCodeRegistryService, ShortCodeRegistryService>();
            services.AddTransient<IApplicationInfoService, ApplicationInfoService>();
        }
    }
}
