using GraphQL;
using SmsBytes.ShortCodeRegistry.Business;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Extensions
{
    public static class Inputs
    {
        public static SetShortCodeInput ShortCodeInput(this IResolveFieldContext x, string name)
        {
            return x.GetArgument<SetShortCodeInput>(name);
        }
    }
}
