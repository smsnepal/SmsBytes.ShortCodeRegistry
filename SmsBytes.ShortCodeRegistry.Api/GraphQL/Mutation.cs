using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Extensions;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Types;
using SmsBytes.ShortCodeRegistry.Business;
using SmsBytes.ShortCodeRegistry.Storage;
using SetShortCodeInput = SmsBytes.ShortCodeRegistry.Api.GraphQL.Inputs.SetShortCodeInput;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(IShortCodeRegistryService service, IHttpContextAccessor httpContextAccessor)
        {
            FieldAsync<NonNullGraphType<ShortCodeDetailsType>, ShortCodeDetails>(
                "createShortCodeDetails",
                arguments: new QueryArguments(SetShortCodeInput.BuildArgument("input")),
                resolve: x => service.Create(x.ShortCodeInput("input"), httpContextAccessor.GetUserId(),
                    httpContextAccessor.GetAuthHeader())).Authorize();
        }
    }
}
