using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmsBytes.ShortCodeRegistry.Api.Internal.Configs;
using SmsBytes.ShortCodeRegistry.Business;
using SmsBytes.ShortCodeRegistry.Business.ApplicationInfo;
using SmsBytes.ShortCodeRegistry.Common.Uuid;
using SmsBytes.ShortCodeRegistry.Storage;

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
            var appRegistrationUrl = configuration
                .GetSection("Services")
                .Get<Services>()
                .AppRegistration
                .Url;
            services.AddSingleton<IApplicationGraphqlClient>(new ApplicationGraphqlClient(appRegistrationUrl));
        }
    }
}
