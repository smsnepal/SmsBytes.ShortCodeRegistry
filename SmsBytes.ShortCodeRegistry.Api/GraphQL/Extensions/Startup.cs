using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Execution;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Micro.GraphQL.Federation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.DataLoaders;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Directives;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Inputs;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Types;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Extensions
{
    public static class Startup
    {
        public static void ConfigureGraphql(this IServiceCollection services)
        {
            services.EnableFederation<EntityType>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<IDocumentExecutionListener, DataLoaderDocumentListener>();
            services.AddTransient<ISchema, StarterSchema>();
            services.AddTransient<Query>();
            services.AddTransient<Mutation>();
            services.AddTransient<ShortCodeDetailsByApplicationLoader>();
            services.AddTransient<ApplicationType>();
            services.AddTransient<ShortCodeDetailsType>();
            services.AddTransient<SetShortCodeInput>();
            services.AddScoped<RequirePermissionDirectiveVisitor>();
            services.AddScoped<AuthorizeDirectiveVisitor>();
            services
                .AddGraphQL(options =>
                {
                    options.UnhandledExceptionDelegate = ctx =>
                    {
                        ctx.ErrorMessage = ctx.OriginalException.Message;
                    };
                })
                .AddDataLoader()
                .AddSystemTextJson()
                .AddErrorInfoProvider(opts => opts.ExposeExceptionStackTrace = true);
        }
        public static void SetupGraphQl(this IApplicationBuilder app)
        {
            app.UseGraphQL<ISchema>();
            app.UseGraphQLGraphiQL(new GraphiQLOptions
            {
                SubscriptionsEndPoint = null,
                GraphQLEndPoint = "/graphql"
            }, "/ui/graphql");
            app.UseGraphQLPlayground(new PlaygroundOptions
            {
                GraphQLEndPoint = "/graphql",
            }, "/ui/playground");
        }
    }
}
