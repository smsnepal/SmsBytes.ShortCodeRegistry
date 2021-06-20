using GraphQL.DataLoader;
using Micro.GraphQL.Federation;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.DataLoaders;
using SmsBytes.ShortCodeRegistry.Storage;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Types
{
    public sealed class ApplicationType : ObjectGraphType<Application>
    {
        public ApplicationType(ShortCodeDetailsByApplicationLoader loader)
        {
            Name = "Application";
            ExtendByKeys("id");
            Field("id", x => x.Id).External();
            Field<ShortCodeDetailsType, ShortCodeDetails>()
                .Name("short_code_details")
                .ResolveAsync(x => loader.LoadAsync(x.Source.Id));

            ResolveReferenceAsync(async ctx =>
            {
                var id = ctx.Arguments["id"].ToString();
                return new Application
                {
                    Id = id,
                };
            });
        }
    }

    public class Application
    {
        public string Id { set; get; }
    }
}
