using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Micro.GraphQL.Federation;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.DataLoaders;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Extensions;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Types;
using SmsBytes.ShortCodeRegistry.Storage;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL
{
    public sealed class Query : Query<EntityType>
    {
        public Query(ShortCodeDetailsByApplicationLoader loader)
        {
            Field<ShortCodeDetailsType, ShortCodeDetails>()
                .Name("shortCodeDetails")
                .Argument<NonNullGraphType<StringGraphType>>("id")
                .ResolveAsync(x => loader.LoadAsync(x.GetArgument<string>("id")))
                .RequirePermission("short_code:view");
        }
    }
}
